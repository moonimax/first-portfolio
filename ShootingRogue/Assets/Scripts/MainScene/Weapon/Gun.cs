using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //�Ѿ��� ���󰡴� ��ġ
    public Transform startPoint;
    
    PlayerMove playermove;
    public Enemy enemy;

    //���� ���¸� ǥ��
    public bool usepistol;
    public bool usepbullet;
    public bool useassaultrifle;
    public bool useabullet;
    public bool usechemicalgun;
    public bool usecbullet;
    public bool useshotgun;
    public bool usesbullet;


    //��� ����ũ
    public LayerMask Mask;
    
    private TrailRenderer BulletTrail;

    //offset�� �ʿ��� ��� ���
    public Vector3 offset;
    //�ѱ����� �÷��̾� ����
    Vector3 dir;

    Vector3[] shotdir = new Vector3[5];

    //������ ���ݷ�
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

                //�����ִ� ������ ź����� 0�̸�
                if (Bullet.Instance.pmagAmmo <= 0)
                {
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Gundry();
                
                    return;
                }
                //�� ���¿� ���� �ִϸ��̼� ��� 
                Shot();
                //time ��� �ö� ��������? time(2.3) �� lasttime+delay(2.1+2 = 4.1) ���� Ŀ���� ����

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
                    
                //�� ���¿� ���� �ִϸ��̼� ��� 
                assualtShot();
                //time ��� �ö� ��������? time(2.3) �� lasttime+delay(2.1+2 = 4.1) ���� Ŀ���� ����

            
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
                //�� ���¿� ���� �ִϸ��̼� ��� 
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
                //�� ���¿� ���� �ִϸ��̼� ��� 
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
            //����ĳ��Ʈ�� ���� �浹 ������ �����ϴ� �����̳�
            RaycastHit rayhit;
            //�Ѿ��� ���� ���� ������ ����
            dir = GetDirection();
            //źȯ�� �ϳ��� ��
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Pistolsound();
            Bullet.Instance.pmagAmmo -= 1;
            ShootingSystem.Play();
            inventoryUI.BulletUI(Item.Itemtype.Pistolbullet);
            //��������, ����, ���� ���� ����, �Ÿ�
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
            //����ĳ��Ʈ�� ���� �浹 ������ �����ϴ� �����̳�
            RaycastHit rayhit;
            //�Ѿ��� ���� ���� ������ ����
            dir = GetDirection();
            //źȯ�� �ϳ��� ��
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Assaultriflesound();
            Bullet.Instance.rmagAmmo -= 1;
            Debug.Log("�ѹ��� ��");
            inventoryUI.BulletUI(Item.Itemtype.Riflebullet);
            //��������, ����, ���� ���� ����, �Ÿ�
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
            //����ĳ��Ʈ�� ���� �浹 ������ �����ϴ� �����̳�
            RaycastHit rayhit;
            //�Ѿ��� ���� ���� ������ ����
            shotdir = shotgunGetDirection();

            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Shotgunsound();
            Bullet.Instance.smagAmmo -= 1;
            inventoryUI.BulletUI(Item.Itemtype.Shotgunbullet);
            
            for (int i = 0; i < 5; i++)
            {
                //��������, ����, ���� ���� ����, �Ÿ�
                if (Physics.Raycast(startPoint.position, shotdir[i], out rayhit, 100, Mask))
                {
                    TrailRenderer trail = Instantiate(BulletTrail, startPoint.position, Quaternion.identity);

                    Debug.Log("������ �߻��");
                    StartCoroutine(Spawntrail(trail, rayhit));

                    if (rayhit.collider.tag == "Enemy")
                    {
                        rayhit.collider.GetComponent<EnemyStat>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                        //enemy.TakeDamage(weapondamage);
                    }
                    if (rayhit.collider.tag == "Box")
                    {
                        rayhit.collider.GetComponent<Enemybox>().TakeDamage(weapondamage + PlayerStats.Instance.playeratk);
                        Debug.Log("�ڽ����� �������� �ִ���");
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
            //����ĳ��Ʈ�� ���� �浹 ������ �����ϴ� �����̳�
            RaycastHit rayhit;
            //�Ѿ��� ���� ���� ������ ����
            dir = GetDirection();

            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Pistolsound();
            Bullet.Instance.cmagAmmo -= 1;
            inventoryUI.BulletUI(Item.Itemtype.Chemicalbullet);
            //��������, ����, ���� ���� ����, �Ÿ�
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