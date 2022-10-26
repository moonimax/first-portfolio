using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnboss1 : MonoBehaviour
{
    public GameObject BossUI;

    public GameObject DoorClose;
    public GameObject WolfBoss;
    public GameObject Portal;
    public GameObject Keybox;
    public GameObject showbossmessage;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().isWolf = false;
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().isKnight = false;
    }
    private void OnEnable()
    {
    }

    public void Yesbossstage()
    {
        WolfBoss.SetActive(true);
        showbossmessage.SetActive(false);
        Keybox.SetActive(false);
        //�̿����� ���谡 �ִٰ� ��Ż�� �����Ǵ°��� ����
        GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>().getkey--;
        Portal.SetActive(false);
        
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Wolfsong();
        BossUI.SetActive(true);
        
        DoorClose.SetActive(true);
        DoorClose.GetComponentInChildren<BoxCollider>().isTrigger = false;

        this.gameObject.SetActive(true);
    }
}
