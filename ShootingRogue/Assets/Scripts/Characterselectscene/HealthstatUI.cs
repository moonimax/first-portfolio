using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthstatUI : MonoBehaviour
{
    SaveStarpick saveStarpick;
    CharacterManager characterManager;

    public Transform HealthUI;
    private Image[] image;

    int num;
    void Start()
    {
        saveStarpick = SaveStarpick.instance;
        characterManager = CharacterManager.instance;
        image = HealthUI.GetComponentsInChildren<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        check();
        Setcolor();
    }

    private void Setcolor()
    {
        if (characterManager.characteritems[num].life < 200)
            image[0].color = Color.red;

        if(characterManager.characteritems[num].life >= 200 && characterManager.characteritems[num].life < 400)
        {
            image[0].color = Color.red;
            image[1].color = Color.red;
        }
        if(characterManager.characteritems[num].life >= 400 && characterManager.characteritems[num].life < 600)
        {
            image[0].color = Color.red;
            image[1].color = Color.red;
            image[2].color = Color.red;
        }
    }

    void check()
    {
        num = saveStarpick.staritems.number;
    }
}
