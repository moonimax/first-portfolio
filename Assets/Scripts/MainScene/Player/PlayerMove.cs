using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    int currentequipvalue;

    public float x;
    
    public float z;
   
    public float speed = 5;
    Vector3 movevec;
    public Transform playerposition;

    bool eDown;
    bool dDown;
    bool jDown;
    bool isDodge;
    bool fire1Down;

    bool isBorder;

    //pistol의 총 쿨타임
    float countdown = 0f;
    float pistolfillcountdown = 0.99f;
    float chemicalgunfillcountdown = 0.69f;
    float assaultfillcountdown = 0.14f;
   // float shotgunfillcountdown = 0.49f;
    float Kinfefillcountdown = 0.3f;
    
    [SerializeField]
    public bool ispoint = false;
    public bool isjump;

    bool soundoff = false;

    public Vector3 nextVec;

    //주변에 있는 것을 감지
    [HideInInspector]
    public GameObject nearObject;
    public GameObject KnifeHeatbox;
    public Camera followCamera;

    public Rigidbody rigid;
    Realmove realmove;

    [SerializeField]
    private KeyCode jumpkeyCode = KeyCode.Space;
    private KeyCode dodgekeyCode = KeyCode.LeftShift;
    private KeyCode interactkeyCode = KeyCode.E;

    private Movement3D movement3D;
    private PlayerAnimator playerAnimator;
    public enum PlayerStat
    {
        None,
        Pistol,
        Assaultrifle,
        Chemicalgun,
        Shotgun,
        Knife
    }
    PlayerStat currentStat = PlayerStat.None;

    

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        playerAnimator = GetComponent<PlayerAnimator>();
        rigid = GetComponent<Rigidbody>();
    }
    void Start()
    {
        realmove = GetComponentInParent<Realmove>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.position;


        if (x != 0 || z != 0)
        {
           GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().walkSound();
           
        }
        //else
        //{
        //    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().walkSound();

        //}

        UpdateState();
         
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        GetInput();
        if(currentequipvalue == 0)
        {
            currentStat = PlayerStat.None;
        }

        //애니메이션 파라미터 설정(horizontal, vertical)
        if (currentequipvalue == 1)
        {
            currentStat = PlayerStat.Pistol;
        }

        if(currentequipvalue == 2)
        {
            currentStat = PlayerStat.Assaultrifle;
        }

        if (currentequipvalue == 3)
        {
            currentStat = PlayerStat.Chemicalgun;
        }
        
        if (currentequipvalue == 4)
        {
            currentStat = PlayerStat.Shotgun;
        }

        if (currentequipvalue == 5)
        {
            currentStat = PlayerStat.Knife;
        }



        //이동함수 호출(카메라가 보고있는 방향을 기준으로 방향키에 따라 이동)
        //플레이어 이동 담당
       // Move();
        //movement3D.MoveTo(new Vector3(x,0,z));
        Turn();
        Jump();
        Dodge();
        
    }

    private void FixedUpdate()
    {
      
        StopToWall();
    }

    public void UpdateState()
    {
        switch (currentStat)
        {
            case PlayerStat.None:
                playerAnimator.baseOn();
                playerAnimator.baseOnMovement(x, z);
                
                break;
        
            case PlayerStat.Pistol:
                playerAnimator.pistolOnMovement(x, z);
                pistolCool();
                playerAnimator.pistolOn();
                break;

            case PlayerStat.Assaultrifle:
                 playerAnimator.assaultOnMovement(x, z);
                 assaultrifleCool();
                 playerAnimator.assaultOn();
                 break;

            case PlayerStat.Chemicalgun:
                playerAnimator.pistolOnMovement(x, z);
                chemicalgunCool();
                playerAnimator.pistolOn();
                break;

            case PlayerStat.Shotgun:
                playerAnimator.assaultOnMovement(x, z);
                shotgunCool();
                playerAnimator.assaultOn();
                break;

            case PlayerStat.Knife:
                playerAnimator.KnifeMovement(x, z);
                KinfeCool();
                playerAnimator.KnifeOn();
                break;
        }

    }
    void pistolCool()
    {
        
          if (Input.GetMouseButton(0))
          {
            if (Bullet.Instance.pmagAmmo <= 0) return;

              if (countdown <= 0)
                {
                    playerAnimator.pistolshoot();
                    //movement3D.MoveTo(transform.rotation * new Vector3(0,0,0));
                    playerAnimator.pistolOnMovement(0, 0);
                    countdown = pistolfillcountdown;
                }
                countdown -= Time.deltaTime;
          }
            
        
        return;
    }

    void KinfeCool()
    {
        if (Input.GetMouseButton(0))
        {
            if(countdown <= 0)
            {
                playerAnimator.Knifeuse();
                KnifeHeatbox.SetActive(true);
                //movement3D.MoveTo(transform.rotation * new Vector3(0,0,0));
                playerAnimator.KnifeMovement(0,0);
                countdown = Kinfefillcountdown;
            }
            countdown -= Time.deltaTime;
        }
    }

    void chemicalgunCool()
    {
        if(Bullet.Instance.cmagAmmo <= 0) return;
       
        if (Input.GetMouseButton(0))
        {
            if (countdown <= 0)
            {
                playerAnimator.pistolshoot();
               // movement3D.MoveTo(transform.rotation * new Vector3(0, 0, 0));
                playerAnimator.pistolOnMovement(0, 0);
                countdown = chemicalgunfillcountdown;
            }
            countdown -= Time.deltaTime;
        }


        return;
    }
    void assaultrifleCool()
    {
        if(Bullet.Instance.rmagAmmo <= 0) return;
        if (Input.GetMouseButton(0))
        {
            if (countdown <= 0)
            {
                playerAnimator.assaultshoot();
                //movement3D.MoveTo(transform.rotation * new Vector3(0, 0, 0));
                
                countdown = assaultfillcountdown;
                
            }
            countdown -= Time.deltaTime;
        }
    }

    void shotgunCool()
    {
        if (Bullet.Instance.smagAmmo <= 0) return;
        if (Input.GetMouseButton(0))
        {
            playerAnimator.assaultshoot();
            if(countdown <= 0)
            {
                playerAnimator.assaultshoot();
                //movement3D.MoveTo(transform.rotation * new Vector3(0, 0, 0));
                playerAnimator.assaultOnMovement(0, 0);
                countdown = assaultfillcountdown;
            }
            countdown -= Time.deltaTime;
        }
    }


    void Jump()
    {
        if (jDown && !isjump && !isDodge)
        {
            realmove.Jump();
            playerAnimator.OnJump();
            isjump = true;

            Invoke("Stopjump", 0.5f);
        }

    }

    void Stopjump()
    {
        isjump = false;
    }

    void Move()
    {
        movevec = new Vector3(x, 0, z).normalized;
        

    }
    void Turn()
    {
        /*
        if (fire1Down)
        {
            ispoint = true;
          */  Ray ray = followCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayhit;
            if (Physics.Raycast(ray, out rayhit, 100))
            {
                nextVec = rayhit.point - transform.position;
                nextVec.y = 0;
            //Quaternion lookrotation = Quaternion.LookRotation(new Vector3(0, nextVec.y, 0));
            transform.rotation = Quaternion.LookRotation(nextVec);    
            //transform.LookAt(transform.position + nextVec);
                //transform.postition + nextVec
            }
        }/*
        else
            ispoint = false;
*/    

    void Dodge()
    {
        if (dDown && !isjump && !isDodge)
        {
            speed *= 2;

            playerAnimator.OnDodge();
            isDodge = true;

            Invoke("DodgeOut", 0.4f);
            
        }
    }

    void DodgeOut()
    {
        speed *= 0.5f;
        isDodge = false;
    }

    
    

    void GetInput()
    {
       
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        jDown = Input.GetKeyDown(jumpkeyCode);
        dDown = Input.GetKeyDown(dodgekeyCode);
        eDown = Input.GetKeyDown(interactkeyCode);
        fire1Down = Input.GetMouseButton(1);
    }

    void StopToWall()
    {
        isBorder = Physics.Raycast(transform.position, transform.forward, 3, LayerMask.GetMask("Wall"));
    }


    public void checkAni(int itemvalue)
    {
        currentequipvalue = itemvalue;
    }

}
