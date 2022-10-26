using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio1 : MonoBehaviour
{
    float count = 0;
    float number = 0;

    public bool isWolf;
    public bool isKnight;

    private AudioManager m_audioSource;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainScene" || SceneManager.GetActiveScene().name == "LevelScene")
        {

            AudioManager.instance.PlayBgm("MainBgm");
        }
        if (SceneManager.GetActiveScene().name == "Playtest1" || SceneManager.GetActiveScene().name == "Playtest1-2" || SceneManager.GetActiveScene().name == "Playtest1-3")
        {
            AudioManager.instance.PlayBgm("Chapter1");

        }

        if (SceneManager.GetActiveScene().name == "Playtest2-1" || SceneManager.GetActiveScene().name == "Playtest2-2" || SceneManager.GetActiveScene().name == "Playtest2-3")
        {
            AudioManager.instance.PlayBgm("Chapter2");

        }

        Debug.Log(SceneManager.GetActiveScene().name);
    }


    void Update()
    {
        
    }

    public void Checkscene()
    {
        if (SceneManager.GetActiveScene().name == "MainScene" || SceneManager.GetActiveScene().name == "LevelScene")
        {

            AudioManager.instance.PlayBgm("MainBgm");
        }
        if (SceneManager.GetActiveScene().name == "Playtest1" || SceneManager.GetActiveScene().name == "Playtest1-2" || SceneManager.GetActiveScene().name == "Playtest1-3")
        {
            AudioManager.instance.PlayBgm("Chapter1");

        }

        if (SceneManager.GetActiveScene().name == "Playtest2-1" || SceneManager.GetActiveScene().name == "Playtest2-2" || SceneManager.GetActiveScene().name == "Playtest2-3")
        {
            AudioManager.instance.PlayBgm("Chapter2");

        }

        Debug.Log(SceneManager.GetActiveScene().name);
    }


    public void Buttonclick()
    {
        
        AudioManager.instance.Play("Buttonclick");
    }

    public void walkSound()
    {
        if (count == 0)
        {
            AudioManager.instance.Play("Walk");
            count++;
        }
        else
            return;
            
        if (number <= 0)
        {
            number = 2;
            count--;
        }
        number -= Time.deltaTime;
            //count °¡ 1ÀÌ µÊ
    }

    public void Pistolsound()
    {
        AudioManager.instance.Play("Gunshot");
    }

    public void Assaultriflesound()
    {
        AudioManager.instance.Play("Assaultfire");
    }

    public void Shotgunsound()
    {
        AudioManager.instance.Play("Shotgun");
    }

    public void Gundry()
    {
        AudioManager.instance.Play("Gundry");
    }

    public void Reload()
    {
        AudioManager.instance.Play("Reload");
    }

    public void Coindrop()
    {
        AudioManager.instance.Play("Coin");
    }

    public void Wolfsong()
    {
        AudioManager.instance.PlayBgm("Wolf");
    }

    public void Knightsong()
    {
        AudioManager.instance.PlayBgm("Knight");
    }

    public void WinBgm()
    {
        AudioManager.instance.PlayBgm("Win");
    }

    public void WinSBX()
    {
        AudioManager.instance.Play("WinSBX");
    }

    public void Dagger()
    {
        AudioManager.instance.Play("Dagger");
    }

}
