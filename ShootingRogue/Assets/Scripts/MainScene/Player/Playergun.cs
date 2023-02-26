using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playergun : MonoBehaviour
{
    
   public int currentequipvalue;
   public int currentequip;
    //���� �÷��̾��� ������ݷ�
   public float weapondmg; 

    //���� ��ũ��Ʈ
    public GameObject pistoldefault;
    public GameObject assaultrifle;
    public GameObject chemicalgun;
    public GameObject shotgun;
    //public GameObject pistoldefault;
    
    PlayerAnimator playerAnimator;

    float preloadTime = 1f;
    float rreloadTime = 2.5f;
    float creloadTime = 3f;
    float sreloadTime = 3f;

    public void Check(int itemvalue)
    {
        currentequipvalue = itemvalue;
        Debug.Log(currentequipvalue + "�� �Ѿ��");
    }

    public void Checkweapondmg(float damage)
    {
        weapondmg = damage;
    }

    void Start()
    {
        pistoldefault.GetComponent<Gun>().enabled = false;
        assaultrifle.GetComponent<Gun>().enabled = false;
        chemicalgun.GetComponent<Gun>().enabled = false;
        shotgun.GetComponent<Gun>().enabled = false;

        playerAnimator = GetComponent<PlayerAnimator>();
        //ó���� �������ڸ��� 0�� �⺻���̱� ������ �ƿ� ū���� �༭ Reload 
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Reload();
            Reload();
        }
    }

    //�ٲ� ���� ���¿� ���� gunsript�� Ȱ��/��Ȱ��ȭ��Ŵ
    public void checkequipvalue()
    {
        //currentequipvalue = itemvalue;
        //Debug.Log("���� �������� ���� :" + currentequipvalue);

        if (currentequipvalue == 1)
        {
            pistoldefault.GetComponent<Gun>().enabled = true;
            assaultrifle.GetComponent<Gun>().enabled = false;
            chemicalgun.GetComponent<Gun>().enabled = false;
            shotgun.GetComponent<Gun>().enabled = false;
        }


        if (currentequipvalue == 2)
        {
            pistoldefault.GetComponent<Gun>().enabled = false;
            assaultrifle.GetComponent<Gun>().enabled = true;
            chemicalgun.GetComponent<Gun>().enabled = false;
            shotgun.GetComponent<Gun>().enabled = false;
        }

        if (currentequipvalue == 3)
        {
            pistoldefault.GetComponent<Gun>().enabled = false;
            assaultrifle.GetComponent<Gun>().enabled = false;
            chemicalgun.GetComponent<Gun>().enabled = true;
            shotgun.GetComponent<Gun>().enabled = false;
        }

        if (currentequipvalue == 4)
        {
            pistoldefault.GetComponent<Gun>().enabled = false;
            assaultrifle.GetComponent<Gun>().enabled = false;
            chemicalgun.GetComponent<Gun>().enabled = false;
            shotgun.GetComponent<Gun>().enabled = true;
        }
    }

    void Reload()
    {
            if (currentequipvalue == 0) return;
            //�����̰�
            if (currentequipvalue == 1)
            {   //pistolbullet���� ���ų� �����ִ� źȯ�� �� ���뷮���� ���ٸ�

                if (Bullet.Instance.remainpistolbullet <= 0 || Bullet.Instance.pmagCapacity <= Bullet.Instance.pmagAmmo)
                {
                    return;
                }
                else
                StartCoroutine(PistolReloadRoutine());
            }
        
            if (currentequipvalue == 2)
            {   //riflebullet���� ���ų� �����ִ� źȯ�� �� ���뷮���� ���ٸ�
                if (Bullet.Instance.remainriflebullet <= 0 || Bullet.Instance.rmagCapacity <= Bullet.Instance.rmagAmmo)
                {
                    return;
                }
                else
                StartCoroutine(rifleReloadRoutine());
            }

            if (currentequipvalue == 3)
            {
                if (Bullet.Instance.remainchemicalbullet <= 0 || Bullet.Instance.cmagCapacity <= Bullet.Instance.cmagAmmo)
                {
                    return;
                }
                else
                StartCoroutine(chemicalReloadRoutine());
            }

            if (currentequipvalue == 4)
            {
                if (Bullet.Instance.remainshotgunbullet <= 0 || Bullet.Instance.smagCapacity <= Bullet.Instance.smagAmmo)
                {
                    return;
                }
                else
                StartCoroutine(shotgunReloadRoutine());
            }

    }

    private IEnumerator PistolReloadRoutine()
    //R��ư�� ������ ������
    {
        //���� �����̶��
        if (currentequipvalue == 1)
        {
            //���� �����ϴ� �ִϸ��̼��� ������
            playerAnimator.onpReload();

            Debug.Log("1������ư�� ����");

            //�������ϴ� �ҿ� �ð���ŭ ó���� ����
            yield return new WaitForSeconds(preloadTime);

            //ä�����ϴ� �Ѿ��� ����
            var ammoToFill = Bullet.Instance.pmagCapacity - Bullet.Instance.pmagAmmo;

            // źâ�� ä������ ź���� ���� ź�ຸ�� ���ٸ�,
            // ä������ ź�� ���� ���� ź�� ���� ���� ���δ�
            if (Bullet.Instance.remainpistolbullet < Bullet.Instance.pmagCapacity)
                ammoToFill = Bullet.Instance.remainpistolbullet;

            Debug.Log("remainpistolbullet" + Bullet.Instance.remainpistolbullet);

            //źâ�� ä���
            Bullet.Instance.pmagAmmo += ammoToFill;

            //���� ź�࿡��, źâ�� ä�ŭ ź���� ����
            Bullet.Instance.remainpistolbullet -= ammoToFill;

            yield return null;

        } 
    }

    private IEnumerator rifleReloadRoutine() {
        //������ ���̶��
        if (currentequipvalue == 2)
        {
            //���� �����ϴ� �ִϸ��̼��� ������
            playerAnimator.onrReload();
            //�������ϴ� �ҿ� �ð���ŭ ó���� ����
            yield return new WaitForSeconds(rreloadTime);

            //ä�����ϴ� �Ѿ��� ����
            var ammoToFill = Bullet.Instance.rmagCapacity - Bullet.Instance.rmagAmmo;

            // źâ�� ä������ ź���� ���� ź�ຸ�� ���ٸ�,
            // ä������ ź�� ���� ���� ź�� ���� ���� ���δ�
            if (Bullet.Instance.remainriflebullet < Bullet.Instance.rmagCapacity)
                ammoToFill = Bullet.Instance.remainriflebullet;

            //źâ�� ä���
            Bullet.Instance.rmagAmmo += ammoToFill;

            //���� ź�࿡��, źâ�� ä�ŭ ź���� ����
            Bullet.Instance.remainriflebullet -= ammoToFill;

        }
    }

    private IEnumerator chemicalReloadRoutine()
    { //ȭ�����̶��
        if (currentequipvalue == 3)
        {
            //���� �����ϴ� �ִϸ��̼��� ������
            playerAnimator.onpReload();

            //�������ϴ� �ҿ� �ð���ŭ ó���� ����
            yield return new WaitForSeconds(creloadTime);

            //ä�����ϴ� �Ѿ��� ����
            var ammoToFill = Bullet.Instance.cmagCapacity - Bullet.Instance.cmagAmmo;

            // źâ�� ä������ ź���� ���� ź�ຸ�� ���ٸ�,
            // ä������ ź�� ���� ���� ź�� ���� ���� ���δ�
            if (Bullet.Instance.remainchemicalbullet < Bullet.Instance.cmagCapacity)
                ammoToFill = Bullet.Instance.remainchemicalbullet;

            //źâ�� ä���
            Bullet.Instance.cmagAmmo += ammoToFill;

            //���� ź�࿡��, źâ�� ä�ŭ ź���� ����
            Bullet.Instance.remainchemicalbullet -= ammoToFill;

        }
    }
    private IEnumerator shotgunReloadRoutine()
    {

            if(currentequipvalue == 4)
            {
                //���� �����ϴ� �ִϸ��̼��� ������
                playerAnimator.onrReload();

                //�������ϴ� �ҿ� �ð���ŭ ó���� ����
                yield return new WaitForSeconds(sreloadTime);

                //ä�����ϴ� �Ѿ��� ����
                var ammoToFill = Bullet.Instance.smagCapacity - Bullet.Instance.smagAmmo;

                // źâ�� ä������ ź���� ���� ź�ຸ�� ���ٸ�,
                // ä������ ź�� ���� ���� ź�� ���� ���� ���δ�
                if (Bullet.Instance.remainshotgunbullet < Bullet.Instance.smagCapacity)
                    ammoToFill = Bullet.Instance.remainshotgunbullet;

                //źâ�� ä���
                Bullet.Instance.smagAmmo += ammoToFill;

                //���� ź�࿡��, źâ�� ä�ŭ ź���� ����
                Bullet.Instance.remainshotgunbullet -= ammoToFill;

            }

    }
    

    
}
