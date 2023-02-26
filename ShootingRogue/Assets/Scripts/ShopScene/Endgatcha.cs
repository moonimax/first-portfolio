using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endgatcha : MonoBehaviour
{   
    [HideInInspector]
    public GameObject Showgatcha;
    [HideInInspector]
    public GameObject boximage;
    [HideInInspector]
    public GameObject boxtopimage;
    [HideInInspector]
    public GameObject boxbuttomimage;
    [HideInInspector]
    public GameObject gatchaimage;
    [HideInInspector]
    public GameObject edgePanel;
    [HideInInspector]
    public GameObject ppShow;
    [HideInInspector]
    public GameObject ppimage;

    GatchaUI gatchaUI;

    private void Start()
    {
        gatchaUI = GetComponentInParent<GatchaUI>();   
        
    }
    public void Hidegatcha()
    {
        boximage.SetActive(true);

        edgePanel.SetActive(false);
        boxtopimage.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,-4);
        boxtopimage.GetComponent<Image>().color = new Color(255,255,255,1);
        boxbuttomimage.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        boxbuttomimage.GetComponent<Image>().color = new Color(255,255,255,1);
        ppimage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Catchaitem/PP");
        //뽑힌 이미지를 초기화 시켜야함
        gatchaimage.GetComponent<RectTransform>().sizeDelta = new Vector2(115, 81);
        //마지막으로 UI 없앰
        Showgatcha.SetActive(false);
        //마지막에 갓차버튼 다시 누르는걸 켜줌
        gatchaUI.stopgatcha = false;

        gameObject.SetActive(false);
    }
}
