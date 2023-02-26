using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatchabutton : MonoBehaviour
{
    public GameObject showgatcha;
    public GameObject ppShow;
    public GameObject edgepanel;

    PlayermoneyManager playermoneyManager;
    public GameObject playercoinUI;
    float cost = 30;
    void Start()
    {
        playermoneyManager = playercoinUI.GetComponent<PlayermoneyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button()
    {
        //±¸¸Å½Ã 30ÀÇ ÁªÀÌ »ç¶óÁü
        if (CharacterManager.instance.gem < cost)
            return;
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        showgatcha.SetActive(true);
        ppShow.SetActive(false);
        edgepanel.SetActive(false);
        
        CharacterManager.instance.gem -= cost;

    }
}
