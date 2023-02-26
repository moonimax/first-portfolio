using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text playerhealthtext;
    public Text startplayerhealthbar;
    public Image playerhealth;

    public Text playerAtk;

    public Text gold;
    PlayerStats playerstat;

    
    Playergun playergun;
    void Start()
    {
        playerstat = PlayerStats.Instance;
        playergun = GameObject.FindGameObjectWithTag("Player").GetComponent<Playergun>();
        playerstat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        //Deadimg.color = new Color(0f, 0f, 0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        

        playerhealthtext.text = Mathf.Round(playerstat.playerHealth).ToString();
        startplayerhealthbar.text = "/" + playerstat.playerstartHealth.ToString();
        playerhealth.fillAmount = playerstat.playerHealth / playerstat.playerstartHealth;

        //플레이어 공격력 담당
        playerAtk.text = string.Format("{0:00}", playerstat.playeratk);
        gold.text = playerstat.gold.ToString();
    }

    
}
