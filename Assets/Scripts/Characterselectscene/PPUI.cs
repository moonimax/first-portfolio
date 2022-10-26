using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPUI : MonoBehaviour
{
    SaveStarpick saveStarpick;
    CharacterManager characterManager;

    public GameObject nowpp;
    public GameObject needpp;

    Image image;
    int num;

    void Start()
    {
        saveStarpick = SaveStarpick.instance;
        characterManager = CharacterManager.instance;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        check();
        Setneedpp();
    }

    void Setneedpp()
    {
        nowpp.GetComponent<Text>().text = characterManager.characteritems[num].piece.ToString();
        needpp.GetComponent<Text>().text = characterManager.characteritems[num].needtoUpgrade.ToString();
        image.fillAmount = characterManager.characteritems[num].piece / characterManager.characteritems[num].needtoUpgrade;
    }

    void check()
    {
        num = saveStarpick.staritems.number;
    }
}
