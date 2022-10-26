using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playergun : MonoBehaviour
{
    
   public int currentequipvalue;
   public int currentequip;
    //현재 플레이어의 무기공격력
   public float weapondmg; 

    //권총 스크립트
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
        Debug.Log(currentequipvalue + "가 넘어옴");
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
        //처음에 시작하자마자 0이 기본값이기 떄문에 아예 큰값을 줘서 Reload 
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Reload();
            Reload();
        }
    }

    //바뀐 총의 상태에 따라 gunsript를 활성/비활성화시킴
    public void checkequipvalue()
    {
        //currentequipvalue = itemvalue;
        //Debug.Log("현자 착용중인 장비는 :" + currentequipvalue);

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
            //권총이고
            if (currentequipvalue == 1)
            {   //pistolbullet보다 적거나 남아있는 탄환이 총 수용량보다 많다면

                if (Bullet.Instance.remainpistolbullet <= 0 || Bullet.Instance.pmagCapacity <= Bullet.Instance.pmagAmmo)
                {
                    return;
                }
                else
                StartCoroutine(PistolReloadRoutine());
            }
        
            if (currentequipvalue == 2)
            {   //riflebullet보다 적거나 남아있는 탄환이 총 수용량보다 많다면
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
    //R버튼을 누르면 재장전
    {
        //만약 권총이라면
        if (currentequipvalue == 1)
        {
            //총을 장전하는 애니메이션을 실행함
            playerAnimator.onpReload();

            Debug.Log("1장전버튼을 눌름");

            //재장전하는 소요 시간만큼 처리를 쉬기
            yield return new WaitForSeconds(preloadTime);

            //채워야하는 총알의 개수
            var ammoToFill = Bullet.Instance.pmagCapacity - Bullet.Instance.pmagAmmo;

            // 탄창에 채워야할 탄약이 남은 탄약보다 많다면,
            // 채워야할 탄약 수를 남은 탄약 수에 맞춰 줄인다
            if (Bullet.Instance.remainpistolbullet < Bullet.Instance.pmagCapacity)
                ammoToFill = Bullet.Instance.remainpistolbullet;

            Debug.Log("remainpistolbullet" + Bullet.Instance.remainpistolbullet);

            //탄창을 채운다
            Bullet.Instance.pmagAmmo += ammoToFill;

            //남은 탄약에서, 탄창에 채운만큼 탄약을 뺀다
            Bullet.Instance.remainpistolbullet -= ammoToFill;

            yield return null;

        } 
    }

    private IEnumerator rifleReloadRoutine() {
        //라이플 총이라면
        if (currentequipvalue == 2)
        {
            //총을 장전하는 애니메이션을 실행함
            playerAnimator.onrReload();
            //재장전하는 소요 시간만큼 처리를 쉬기
            yield return new WaitForSeconds(rreloadTime);

            //채워야하는 총알의 개수
            var ammoToFill = Bullet.Instance.rmagCapacity - Bullet.Instance.rmagAmmo;

            // 탄창에 채워야할 탄약이 남은 탄약보다 많다면,
            // 채워야할 탄약 수를 남은 탄약 수에 맞춰 줄인다
            if (Bullet.Instance.remainriflebullet < Bullet.Instance.rmagCapacity)
                ammoToFill = Bullet.Instance.remainriflebullet;

            //탄창을 채운다
            Bullet.Instance.rmagAmmo += ammoToFill;

            //남은 탄약에서, 탄창에 채운만큼 탄약을 뺀다
            Bullet.Instance.remainriflebullet -= ammoToFill;

        }
    }

    private IEnumerator chemicalReloadRoutine()
    { //화학총이라면
        if (currentequipvalue == 3)
        {
            //총을 장전하는 애니메이션을 실행함
            playerAnimator.onpReload();

            //재장전하는 소요 시간만큼 처리를 쉬기
            yield return new WaitForSeconds(creloadTime);

            //채워야하는 총알의 개수
            var ammoToFill = Bullet.Instance.cmagCapacity - Bullet.Instance.cmagAmmo;

            // 탄창에 채워야할 탄약이 남은 탄약보다 많다면,
            // 채워야할 탄약 수를 남은 탄약 수에 맞춰 줄인다
            if (Bullet.Instance.remainchemicalbullet < Bullet.Instance.cmagCapacity)
                ammoToFill = Bullet.Instance.remainchemicalbullet;

            //탄창을 채운다
            Bullet.Instance.cmagAmmo += ammoToFill;

            //남은 탄약에서, 탄창에 채운만큼 탄약을 뺀다
            Bullet.Instance.remainchemicalbullet -= ammoToFill;

        }
    }
    private IEnumerator shotgunReloadRoutine()
    {

            if(currentequipvalue == 4)
            {
                //총을 장전하는 애니메이션을 실행함
                playerAnimator.onrReload();

                //재장전하는 소요 시간만큼 처리를 쉬기
                yield return new WaitForSeconds(sreloadTime);

                //채워야하는 총알의 개수
                var ammoToFill = Bullet.Instance.smagCapacity - Bullet.Instance.smagAmmo;

                // 탄창에 채워야할 탄약이 남은 탄약보다 많다면,
                // 채워야할 탄약 수를 남은 탄약 수에 맞춰 줄인다
                if (Bullet.Instance.remainshotgunbullet < Bullet.Instance.smagCapacity)
                    ammoToFill = Bullet.Instance.remainshotgunbullet;

                //탄창을 채운다
                Bullet.Instance.smagAmmo += ammoToFill;

                //남은 탄약에서, 탄창에 채운만큼 탄약을 뺀다
                Bullet.Instance.remainshotgunbullet -= ammoToFill;

            }

    }
    

    
}
