using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attackstat : MonoBehaviour
{
    SaveStarpick saveStarpick;
    CharacterManager characterManager;

    public Transform AttackUI;
    private Image[] image;

    public int num;

    public bool isUpgrade;

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
    public void Setcolor()
    {
        if (characterManager.characteritems[num].atk < 100)
                image[0].color = Color.green;

            if (characterManager.characteritems[num].atk >= 100 && characterManager.characteritems[num].atk < 200)
            {
                image[0].color = Color.green;
                image[1].color = Color.green;
            }
        if (characterManager.characteritems[num].atk <= 300 && characterManager.characteritems[num].atk >= 200)
        {
            image[0].color = Color.green;
            image[1].color = Color.green;
            image[2].color = Color.green;
        }

    }

    void check()
    {
        num = saveStarpick.staritems.number;
    }
}

/*
 *  if (characterManager.characteritems[num].atk < 100)

        if (characterManager.characteritems[num].atk >= 100 && characterManager.characteritems[num].atk < 200)
        {
            image[0].color = Color.green;
            image[1].color = Color.green;
        }
        if (characterManager.characteritems[num].atk <= 300 && characterManager.characteritems[num].atk >= 200)
        {
            image[0].color = Color.green;
            image[1].color = Color.green;
            image[2].color = Color.green;
        }
*/
