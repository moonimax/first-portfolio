using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    Audio1 audio;

    public SceneFader fader;

    public string menuSceneName = "";
    public string shopscene = "";
    public string levelscene = ".";


    GameObject backgroundMusic;
    AudioSource backmusic;
    private void Awake()
    {
        Time.timeScale = 1F;
        //backgroundMusic = GameObject.FindGameObjectWithTag("Backgroundmusic");
        //backmusic = backgroundMusic.GetComponent<AudioSource>();
        //if (backmusic.isPlaying) return;
    }
    void Start()
    {
        audio = GetComponentInChildren<Audio1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StarsPickUI()
    {
        audio.Buttonclick();
        fader.FadeTo(menuSceneName);
    }

    public void GotoShop()
    {
       audio.Buttonclick();
        fader.FadeTo(shopscene);
    }

    public void GoLevelScene()
    {
        audio.Buttonclick();
        fader.FadeTo(levelscene);
    }
}
