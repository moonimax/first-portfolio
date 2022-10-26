using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defensestat : MonoBehaviour
{
    SaveStarpick saveStarpick;
    CharacterManager characterManager;

    public Transform AttackUI;
    private Image[] image;

    int num;

    void Start()
    {
        characterManager = CharacterManager.instance;
        saveStarpick = SaveStarpick.instance;
        image = AttackUI.GetComponentsInChildren<Image>();

    }
    // Update is called once per frame
    void Update()
    {
        check();
        Setcolor();
    }
    private void Setcolor()
    {
        if (characterManager.characteritems[num].def == 1)
            image[0].color = Color.blue;

        if (characterManager.characteritems[num].def >= 0.8 && characterManager.characteritems[num].def < 1)
        {
            image[0].color = Color.blue;
            image[1].color = Color.blue;
        }
        if (characterManager.characteritems[num].def < 0.8 && characterManager.characteritems[num].def >= 0.6)
        {
            image[0].color = Color.blue;
            image[1].color = Color.blue;
            image[2].color = Color.blue;
        }
        if (characterManager.characteritems[num].def < 0.6 && characterManager.characteritems[num].def >= 0.4)
        {
            image[0].color = Color.blue;
            image[1].color = Color.blue;
            image[2].color = Color.blue;
            image[3].color = Color.blue;
        }
        if (characterManager.characteritems[num].def < 0.4 && characterManager.characteritems[num].def >= 0.2)
        {
            image[0].color = Color.blue;
            image[1].color = Color.blue;
            image[2].color = Color.blue;
        }
    }

    void check()
    {
        num = saveStarpick.staritems.number;
    }
}

