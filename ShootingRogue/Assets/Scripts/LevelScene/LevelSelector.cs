using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    int Clearedlevel;
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    public SceneFader fader;

    public GameObject[] levelButtons;
   
    void Start()
    {
        Clearedlevel = CharacterManager.instance.Clearlevel;

        //그다음에 clearlevel보다 높은 levelbuttons를 막아줌
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > Clearedlevel)
            {
                levelButtons[i].GetComponent<Image>().color = new Color(255, 255, 255, 0.2f);
                levelButtons[i].GetComponent<Button>().interactable = false;
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //버튼 기능들에 사용되는 함수를 여기서 사용함
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
