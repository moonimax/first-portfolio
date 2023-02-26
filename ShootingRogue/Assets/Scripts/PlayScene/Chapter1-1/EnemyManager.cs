using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyManager : MonoBehaviour
{
    public Text enemylefttext;

    public GameObject WinUI;
    public GameObject winzem;

    public GameObject lastkey;

    public bool enemy;
    public bool key;

    public bool Level1;
    public bool Level2;
    public bool Level3;
    public bool Level4;
    public bool Level5;
    public int enemytotal;
    public int enemycount = 3;
    public int goalnumber;
    
    public int getkey;
    public int getkeycount;

    public bool bossStage;

    
    public GameObject portal;

    public GameObject questtype;

    public bool Chapterfinished = false;
    bool stopkey = false;
    bool givezem = false;
    bool keytrue = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == true)
        {
            enemylefttext.text = enemytotal.ToString() + "/" + enemycount.ToString();
          
            if(enemytotal >= enemycount)
            {
                WinUI.SetActive(true);

                if(Level1 == true)
                {
                    CharacterManager.instance.Clearlevel = 2;
                }
                if(Level4 == true)
                {
                    CharacterManager.instance.Clearlevel = 5;
                }

                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().WinBgm();
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().WinSBX();
                if(givezem == false)
                {
                    givezem = true;
                    CharacterManager.instance.gem += 100;
                    StartCoroutine(showzem());
                }
                Time.timeScale = 0.3f;

            }
        }


        if(key == true)
        {
            enemylefttext.text = getkey.ToString() + "/" + getkeycount.ToString();

            if(enemytotal >= goalnumber)
            {
                if (keytrue == false)
                {
                    keytrue = true;
                    lastkey.SetActive(true);
                }            }

            if (getkey == getkeycount)
            {
                //보스스테이지이라면
                if(bossStage == true)
                {
                    questtype.GetComponent<Text>().text = "보스를 처치하십시오";
                    //텔포 생성
                    portal.SetActive(true);

                    //하고 다음 보스 UI를 띄워줌

                }


                //보스스테이지가 아니라면 스테이지를 끝낸다
                if(bossStage == false) 
                { 
                  WinUI.SetActive(true);
                    if(Level2 == true)
                    {
                        CharacterManager.instance.Clearlevel = 3;
                    }
                    if(Level5 == true)
                    {
                        CharacterManager.instance.Clearlevel = 6;
                    }
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().WinBgm();
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().WinSBX();

                    if (givezem == false)
                  {
                    givezem = true;
                    CharacterManager.instance.gem += 100;
                    StartCoroutine(showzem());
                  }
                Time.timeScale = 0.3f;
                }
            }
        }

        //승리의 라운드가 켜지면
        if(Chapterfinished == true)
        {
            WinUI.SetActive(true);
            
            if(Level3 == true)
            {
                CharacterManager.instance.Clearlevel = 4;
            }
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().WinBgm();
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().WinSBX();
            if (givezem == false)
            {
                givezem = true;
                CharacterManager.instance.gem += 300;
                winzem.GetComponentInChildren<Text>().text = "+300";
                StartCoroutine(showzem());
            }
            Time.timeScale = 0.3f;

        }
    }

    public void Addenemytotal()
    {
        enemytotal++;
        return;
    }

    IEnumerator showzem()
    {
        yield return new WaitForSeconds(0.3f);
        
        //애니메이션 재생
        winzem.GetComponent<Animation>().Play("winthezem");
      
    }
}
