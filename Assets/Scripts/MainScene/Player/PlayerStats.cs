using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    SelectedCharater selectedCharater;
    #region Singleton

    public static PlayerStats Instance;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    #endregion

    public bool buffDef;
    public bool buffAtk;

    public float gold = 3000;
    public string name;

    [HideInInspector]
    public float playerHealth;
    public GameObject GameOverUI;
    public float playerstartHealth;
    
    public float playeratk;
    public float def;
    public GameObject Head;
    public GameObject Body;
    int playernum;

    public SceneFader fader;

    Gun gun;
    Playergun playergunstat;

    

    void Start()
    {
        GetselectedCharacterInfo(SelectedCharater.instance.staritem.atk, SelectedCharater.instance.staritem.name, SelectedCharater.instance.staritem.def, SelectedCharater.instance.staritem.life, SelectedCharater.instance.staritem.number);
        Debug.Log("�÷��̾��� ���ݷ���" + playeratk);
        Debug.Log("�÷��̾��� �̸���" + name);

        Head.GetComponent<SkinnedMeshRenderer>().sharedMesh = Resources.Load<Mesh>("Mesh/Head" + playernum);
        Body.GetComponent<SkinnedMeshRenderer>().sharedMesh = Resources.Load<Mesh>("Mesh/Body" + playernum);
        
        

        playerHealth = playerstartHealth;
        playergunstat = GetComponent<Playergun>();

    }


    void Update()
    {
        if(playerHealth <= 0)
        {
            Time.timeScale = 0.3f;
            GameOverUI.SetActive(true);
            //StartCoroutine(gameover());
        }

        Debug.Log("�÷��̾��� ���ݷ���" + playeratk);
    }

    IEnumerator gameover()
    {
        
        yield return new WaitForSeconds(15f);
       fader.FadeTo("LevelScene");
    }

    public void TakeDamage(float damage)
    {
        float dmg;
        dmg = damage * def;
        if (dmg <= 0)
            dmg = 2f;

        playerHealth -= dmg;
        Debug.Log(def);
        Debug.Log("�÷��̾��� ü����:" + playerHealth);
    }

    public void AddHP(float HP)
    {
        playerHealth += HP;

        if (playerHealth > playerstartHealth)
        {
            playerHealth = playerstartHealth;
        }
        
        if(playerHealth <= 0)
        {
            playerHealth = 0;
        }
    }

    public void AddGold(float amount)
    {
        if (amount == 0)
            return;

        gold += amount;

        //����(��������, ��������)
    }

    public bool UseGold(float amount)
    {
        if (amount == 0)
            return true;

        if (gold < amount)
        {
            Debug.Log("���� �����մϴ�");
            return false;
        }

        gold -= amount;

        return true;
    }

    private void GetselectedCharacterInfo(float _atk, string _name, float _def, float _life, int _num)
    {
        playeratk = _atk;
        name = _name;
        playernum = _num;
        def = _def;
        playerstartHealth = _life;
    }

}
