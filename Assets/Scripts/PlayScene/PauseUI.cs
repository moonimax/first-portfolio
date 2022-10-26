using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public SceneFader fader;

    public GameObject pauseUI;

    //메뉴로 돌아가는 이름
    public string menuSceneName = "";
    public string levelselect = "";
    public string nextlevel = "";
    public string bossstage1 = "";
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (pauseUI.activeSelf == false)
            {
                Toggle();

            }
            else if (pauseUI.activeSelf == true)
            {
                Toggle();
                Time.timeScale = 1.0f;
            }

        }

    }

    public void Toggle()
    {

        pauseUI.SetActive(!pauseUI.activeSelf);
        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

    }

    //게임계속하기
    public void Continue()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        Toggle();
    }

    
    public void Menu()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        Time.timeScale = 1f;
        fader.FadeTo(menuSceneName);
    }

    public void LevelSelect()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        Time.timeScale = 1f;
        fader.FadeTo(levelselect);
    }

    public void NextLevel()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        fader.FadeTo(nextlevel);
    }

    public void Yesbossmessage()
    {
       
    }
}
