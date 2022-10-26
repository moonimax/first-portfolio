using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgradebuttonm : MonoBehaviour
{
    CharacterManager characterManager;
    SaveStarpick saveStarpick;
    Image image;

    int num;
    
    float need2 = 30;
    float need3 = 50;
    float need4 = 100;

    void Start()
    {
        characterManager = CharacterManager.instance;
        saveStarpick = SaveStarpick.instance;
        image = GetComponent<Image>();
    }


    void Update()
    {
        num = saveStarpick.staritems.number;
        if (characterManager.characteritems[num].piece < characterManager.characteritems[num].needtoUpgrade)
        {
            image.color = Color.white;

        }
        else
        {
            image.color = Color.yellow;
        }
    }

    public void Upgrademode()
    {
        if (characterManager.characteritems[num].piece < characterManager.characteritems[num].needtoUpgrade)
        {
            return;
        }
        else
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Buttonclick();
            //현재 랭크를 하나 더해준다
            characterManager.characteritems[num].Nowrank++;

            if (characterManager.characteritems[num].Nowrank == 3)
            {
                characterManager.characteritems[num].piece -= characterManager.characteritems[num].needtoUpgrade;
                characterManager.characteritems[num].needtoUpgrade = need4;
                characterManager.characteritems[num].atk = characterManager.characteritems[num].Rank3Atk;
                characterManager.characteritems[num].def = characterManager.characteritems[num].Rank3Def;
                characterManager.characteritems[num].life = characterManager.characteritems[num].Rank3Life;

                return;
               
            }

            if (characterManager.characteritems[num].Nowrank == 2)
            {
                characterManager.characteritems[num].piece -= characterManager.characteritems[num].needtoUpgrade;
                characterManager.characteritems[num].needtoUpgrade = need3;
                characterManager.characteritems[num].atk = characterManager.characteritems[num].Rank2Atk;
                characterManager.characteritems[num].def = characterManager.characteritems[num].Rank2Def;
                characterManager.characteritems[num].life = characterManager.characteritems[num].Rank2Life;
                return;
            }
           
            if (characterManager.characteritems[num].Nowrank == 1)
            {
                characterManager.characteritems[num].piece -= characterManager.characteritems[num].needtoUpgrade;
                characterManager.characteritems[num].needtoUpgrade = need2;
                characterManager.characteritems[num].atk = characterManager.characteritems[num].Rank1Atk;
                characterManager.characteritems[num].def = characterManager.characteritems[num].Rank1Def;
                characterManager.characteritems[num].life = characterManager.characteritems[num].Rank1Life;
                return;
                
            }
            
        }
    }
} 


   

