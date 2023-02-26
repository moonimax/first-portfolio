using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsPickUI : MonoBehaviour
{
    public SceneFader fader;
    public GameObject Message;
    Audio1 audio;

    public string menuSceneName = "";
    public string starmenuName = "";
    public string characterscene = "";
    public string Playscene1 = "";
    public string Playscene2 = "";
    public string Playscene3 = "";
    public string Playtest21 = "";
    public string Playtest22 = "";
    public string Playtest23 = "";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Mainmenu()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        fader.FadeTo(menuSceneName);
    }

    public void Starmenu()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        fader.FadeTo(starmenuName);
    }

    public void Charactermenu()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        fader.FadeTo(characterscene);
    }

    public void Play1()
    {
        if (SelectedCharater.instance.staritem.name == "none") 
        {
            StartCoroutine(showmessage());
            return;
        }
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        fader.FadeTo(Playscene1);
    }

    public void Play2()
    {
        if (SelectedCharater.instance.staritem.name == "none")
        {
            StartCoroutine(showmessage());
            return;
        }
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();

        fader.FadeTo(Playscene2);
    }

    public void Play3()
    {
        if (SelectedCharater.instance.staritem.name == "none")
        {
            StartCoroutine(showmessage());
            return;
        }

        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        fader.FadeTo(Playscene3);
    }

    public void Play21()
    {
        if (SelectedCharater.instance.staritem.name == "none")
        {
            StartCoroutine(showmessage());
            return;
        }

        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        fader.FadeTo(Playtest21);
    }


    public void Play22()
    {
        if (SelectedCharater.instance.staritem.name == "none")
        {
            StartCoroutine(showmessage());
            return;
        }

        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        fader.FadeTo(Playtest22);
    }

    public void Play23()
    {
        if (SelectedCharater.instance.staritem.name == "none")
        {
            StartCoroutine(showmessage());
            return;
        }

        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
        fader.FadeTo(Playtest23);
    }

    IEnumerator showmessage()
    {
        Message.SetActive(true);
        yield return new WaitForSeconds(2f);

        Message.SetActive(false);
    }
}
