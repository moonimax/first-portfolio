using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //총알이 날라가는 위치
    public Transform startPoint;
    
    PlayerMove playermove;
    public Enemy enemy;

    //총의 형태를 표시
    public bool usepistol;
    public bool usepbullet;
    public bool useassaultrifle;
    public bool useabullet;
    public bool usechemicalgun;
    public bool usecbullet;
    public bool useshotgun;
    public bool usesbullet;


    //쏘는 마스크
    public LayerMask Mask;
    
    private TrailRenderer BulletTrail;

    //offset이 필요한 경우 사용
    public Vector3 offset;
    //총구에서 플레이어 방향
    Vector3 dir;

    Vector3[] shotdir = new Vector3[5];

    //무기의 공격력
    public float weapondamage;

    [HideInInspector]
    public float lasttime;
    
    public float delay = 1f;
    
    public Vector3 spread = new Vector3(0.1f, 0.1f, 0.1f);

    public bool AddBulletSpread;

    public GameObject poision;

    InventoryUI inventoryUI;

    [SerializeField]
    private ParticleSystem ShootingSystem;
    [SerializeField]
    private ParticleSystem ImpactParticleSystem;
    private void Start()
    {
        BulletTrail = GetComponentInChildren<TrailRenderer>();
        playermove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        inventoryUI = GameObject.FindGameObjectWithTag("Canvas").GetComponent<InventoryUI>();
    }


    private void Update()
    {
        if (usepistol)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //if (playermove.ispoint != true) return;
                if (playermove.isjump == true) return;

                //남아있는 권총의 탄약수가 0이면
                if (Bullet.Instance.pmagAmmo <= 0)
                {
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Gundry();
                
                    return;
                }
                //총 상태에 따른 애니메이션 재생 
                Shot();
                //time 계속 올라감 언제까지? time(2.3) 이 lasttime+delay(2.1+2 = 4.1) 보다 커질때 까지

            }
        }

        if (useassaultrifle)
        {
            if (Input.GetMouseButton(0))
            {
                // if (playermove.ispoint != true) return;
                if (playermove.isjump == true) return;
                
                if (Bullet.Instance.rmagAmmo <= 0)
                {
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Gundry();
                    return;
                }
                    
                //총 상태에 따른 애니메이션 재생 
                assualtShot();
                //time 계속 올라감 언제까지? time(2.3) 이 lasttime+delay(2.1+2 = 4.1) 보다 커질때 까지

            
            }
        }

        if (usechemicalgun)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // if (playermove.ispoint != true) return;
                if (playermove.isjump == true) return;
                if (Bullet.Instance.cmagAmmo <= 0)
                {
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Gundry();
                    return;
                }
                //총 상태에 따른 애니메이션 재생 
                Chemicalgunshot();

            }
        
        }

        if (useshotgun)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // if (playermove.ispoint != true) return;
                if (playermove.isjump == true) 
                    return;
                //총 상태에 따른 애니메이션 재생 
                if (Bullet.Instance.smagAmmo <= 0)
                {
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Gundry();
                    return;
                }
                    shotgunshot();

            }
        

        }
    }

    private void Shot()
    {

        if (lasttime + delay < Time.time)
        {
            //레이캐스트에 의한 충돌 정보를 저장하는 컨테이너
            RaycastHit rayhit;
            //총알이 맞은 곳을 저장할 변수
            dir = GetDirection();
            //탄환을 하나씩 뺌
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Pistolsound();
            Bullet.Instance.pmagAmmo -= 1;
            ShootingSystem.Play();
            inventoryUI.BulletUI(Item.Itemtype.Pistolbullet);
            //시작지점, 방향, 맞은 곳의 정보, 거리
            if (Physics.Raycast(startPoint.position, dir, out rayhit, 100, Mask))
            {
                TrailRenderer trail = Instantiate(BulletTrail, startPoint.position, Quaternion.identity);
                StartCoroutine(Spawntrail(trail, rayhit));
                if (rayhit.collider.tag == "Enemy")
                {
                    rayhit.collider.GetComponent<EnemyStat>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                    //enemy.TakeDamage(weapondamage);
                }
                if(rayhit.collider.tag == "Box")
                {
                    rayhit.collider.GetComponent<Enemybox>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                }
                if (rayhit.collider.tag == "Boss")
                {
                    rayhit.collider.GetComponentInParent<BossAI>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                }
                if (rayhit.collider.tag == "Boss2")
                {
                    rayhit.collider.GetComponentInParent<KnightBossAI>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                }
                lasttime = Time.time;

            }
            ;
        }

    }

    private void assualtShot()
    {

        if (lasttime + delay < Time.time)
        {
            //레이캐스트에 의한 충돌 정보를 저장하는 컨테이너
            RaycastHit rayhit;
            //총알이 맞은 곳을 저장할 변수
            dir = GetDirection();
            //탄환을 하나씩 뺌
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Assaultriflesound();
            Bullet.Instance.rmagAmmo -= 1;
            Debug.Log("한발을 쏨");
            inventoryUI.BulletUI(Item.Itemtype.Riflebullet);
            //시작지점, 방향, 맞은 곳의 정보, 거리
            if (Physics.Raycast(startPoint.position, dir, out rayhit, 100, Mask))
            {
                TrailRenderer trail = Instantiate(BulletTrail, startPoint.position, Quaternion.identity);
                StartCoroutine(Spawntrail(trail, rayhit));
                if (rayhit.collider.tag == "Enemy")
                {
                    rayhit.collider.GetComponent<EnemyStat>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                    //enemy.TakeDamage(weapondamage);
                }
                if (rayhit.collider.tag == "Box")
                {
                    rayhit.collider.GetComponent<Enemybox>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                }
                if (rayhit.collider.tag == "Boss")
                {
                    rayhit.collider.GetComponentInParent<BossAI>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                }
                if (rayhit.collider.tag == "Boss2")
                {
                    rayhit.collider.GetComponentInParent<KnightBossAI>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                }
                lasttime = Time.time;

            }
        }
    }
    private void shotgunshot()
    {
        if (lasttime + delay < Time.time)
        {
            //레이캐스트에 의한 충돌 정보를 저장하는 컨테이너
            RaycastHit rayhit;
            //총알이 맞은 곳을 저장할 변수
            shotdir = shotgunGetDirection();

            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Shotgunsound();
            Bullet.Instance.smagAmmo -= 1;
            inventoryUI.BulletUI(Item.Itemtype.Shotgunbullet);
            
            for (int i = 0; i < 5; i++)
            {
                //시작지점, 방향, 맞은 곳의 정보, 거리
                if (Physics.Raycast(startPoint.position, shotdir[i], out rayhit, 100, Mask))
                {
                    TrailRenderer trail = Instantiate(BulletTrail, startPoint.position, Quaternion.identity);

                    Debug.Log("샷건이 발사됨");
                    StartCoroutine(Spawntrail(trail, rayhit));

                    if (rayhit.collider.tag == "Enemy")
                    {
                        rayhit.collider.GetComponent<EnemyStat>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                        //enemy.TakeDamage(weapondamage);
                    }
                    if (rayhit.collider.tag == "Box")
                    {
                        rayhit.collider.GetComponent<Enemybox>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                        Debug.Log("박스에게 데미지를 주는중");
                    }
                    if (rayhit.collider.tag == "Boss")
                    {
                        rayhit.collider.GetComponentInParent<BossAI>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                    }
                    if (rayhit.collider.tag == "Boss2")
                    {
                        rayhit.collider.GetComponentInParent<KnightBossAI>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                    }
                    lasttime = Time.time;

                }
            }
        }

    }
    private void Chemicalgunshot()
    {
        if (lasttime + delay < Time.time)
        {   
            //레이캐스트에 의한 충돌 정보를 저장하는 컨테이너
            RaycastHit rayhit;
            //총알이 맞은 곳을 저장할 변수
            dir = GetDirection();

            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Pistolsound();
            Bullet.Instance.cmagAmmo -= 1;
            inventoryUI.BulletUI(Item.Itemtype.Chemicalbullet);
            //시작지점, 방향, 맞은 곳의 정보, 거리
            if (Physics.Raycast(startPoint.position, dir, out rayhit, 100, Mask))
            {
                //ameObject chemicalbullet = Instantiate(chemicalgunbullet, startPoint.position, Quaternion.identity);
                TrailRenderer trail = Instantiate(BulletTrail, startPoint.position, Quaternion.identity);
                trail.gameObject.SetActive(true);
                StartCoroutine(SpawngasTrail(trail, rayhit));
                if (rayhit.collider.tag == "Enemy")
                {
                    rayhit.collider.GetComponent<EnemyStat>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);

                }
                if (rayhit.collider.tag == "Box")
                {
                    rayhit.collider.GetComponent<Enemybox>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                }
                if (rayhit.collider.tag == "Boss")
                {
                    rayhit.collider.GetComponentInParent<BossAI>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                }
                if (rayhit.collider.tag == "Boss2")
                {
                    rayhit.collider.GetComponentInParent<KnightBossAI>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                }
                lasttime = Time.time;

            }
        }
    }

    private Vector3 GetDirection()
    {
        Ray ray = playermove.followCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayhit;
        if (Physics.Raycast(ray, out rayhit, 100))
        {
            dir = (rayhit.point + offset) - startPoint.position;
            dir.y = 0;
           
        }

        if (AddBulletSpread)
        {
            dir += new Vector3
            (
                Random.Range(-spread.x, spread.x),
                Random.Range(-spread.y, spread.y),
                Random.Range(-spread.z, spread.z)
            );
            dir.Normalize();
        }
        return dir;
    }
    
    public IEnumerator Spawntrail(TrailRenderer Trail, RaycastHit Hit)
    {
        float time = 0f;
        Vector3 StartPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(StartPosition, Hit.point + offset, time);
            time += Time.deltaTime / Trail.time;
            yield return null;
        }
        Trail.transform.position = Hit.point;
        Instantiate(ImpactParticleSystem, Hit.point, Quaternion.LookRotation(Hit.normal));
        Destroy(Trail.gameObject, Trail.time);
    }


    
    public IEnumerator SpawngasTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        float time = 0f;
        Vector3 StartPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(StartPosition, Hit.point + offset, time);
            time += Time.deltaTime / Trail.time;
            yield return null;
        }
        Trail.transform.position = Hit.point;
        GameObject pos = Instantiate(poision, Hit.point, Quaternion.identity);
        

        Destroy(Trail.gameObject, Trail.time);
    }

    private Vector3[] shotgunGetDirection()
    {
        Ray ray = playermove.followCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayhit;
        if (Physics.Raycast(ray, out rayhit, 100))
        {
            for(int i = 0; i < 4; i++)
            {
            shotdir[i] = (rayhit.point + offset) - startPoint.position;
            shotdir[i].y = 0;

            }

        }

        if (AddBulletSpread)
        {
            for (int i = 0; i < 4; i++)
            {
                shotdir[i] += new Vector3
                (
                    Random.Range(-spread.x, spread.x),
                    Random.Range(-spread.y, spread.y),
                    Random.Range(-spread.z, spread.z)
                );
                shotdir[i].Normalize();
            }
        }
        return shotdir;
    }
    public IEnumerator SpawnshotgurnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
       float time = 0f;
        Vector3 StartPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(StartPosition, Hit.point + offset, time);
            time += Time.deltaTime / Trail.time;
            yield return null;
        }
        Trail.transform.position = Hit.point;

        Destroy(Trail.gameObject, Trail.time);
    }
    public virtual void Use()
    {
        
    }
    
}