using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    protected Animator animator;
    protected EnemyAnimator xanimator;
    private NavMeshAgent nav;
    
    private GameObject player;
    public float Rewardgold;


    [SerializeField]
    private float findrange = 20f;
    [SerializeField]
    private float walkrange = 15f;
    //private float attackrange = 2f;

    //공격 랜덤플레이를 초기화
    protected int attackMode = 0;

    private EnemyStat enemystat;

    bool dead = false;

    Vector3 playerpos;
    private Vector3 dir;
    private float dist; 
    public enum EnemyStates
    {
        Idle,
        Walk,
        Attack
    }
    
    private EnemyStates enemyState = EnemyStates.Idle;


    void Start()
    {
       enemystat = GetComponent<EnemyStat>();
        animator = GetComponent<Animator>();
        xanimator = GetComponent<EnemyAnimator>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    public void UpdateState()
    {
        switch (enemyState)
        {
            case EnemyStates.Idle:
                Idle();
                break;

            case EnemyStates.Walk:
                Walk();
                break;

            case EnemyStates.Attack:
                Attack();
                break;
        }
    }
    void Update()
    {
        if(enemystat.enemyHealth <= 0)
        {
            Die();
            if (dead == false)
            {
                dead = true;
                GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>().Addenemytotal();
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Coindrop();
                PlayerStats.Instance.gold += Rewardgold;
            
            }
            return;
        }
        //두 객체간의 거리
        dist = Vector3.Distance(player.transform.position, transform.position);
        dir = player.transform.position - transform.position;

        UpdateState();
   }

    void Idle()
    {
        if (dist > findrange)
        {   //Idle normal 애니메이션
            xanimator.Idle();
        }
        
     
        if(dist <= findrange && dist > walkrange)
        {
           xanimator.Sense();
        }

        if (dist <= walkrange)
        {
            enemyState = EnemyStates.Walk;
          
        }   

        if(dist <= nav.stoppingDistance)
        {
            enemyState = EnemyStates.Attack;
        }
    }

    void Walk()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        if(dist > walkrange)
        {
            enemyState = EnemyStates.Idle;
        }
        xanimator.Walk();
        checkDestination();
        
        if(dist <= nav.stoppingDistance)
        {   
            enemyState = EnemyStates.Attack;
        }
    }

    void Attack()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        if (dist >= nav.stoppingDistance)
        {
            enemyState = EnemyStates.Walk;
        }
        //slime이 프레임마다 player를 따라가게함
        transform.rotation = Quaternion.LookRotation(dir);

        if (attackMode == 0)
        {
            StartCoroutine(Attackpattern());
        }
    }

    void checkDestination()
    {
        if (nav.destination == null)
        {
            nav.destination = player.transform.position;
        }
        else
        {
            nav.destination = player.transform.position;
        }
    }

    protected virtual IEnumerator Attackpattern()
    {
        /*
        attackMode = Random.Range(1, 3);
        if(attackMode == 1)
        {
            xanimator.Atk1();
            Debug.Log("atk1");
            yield return new WaitForSeconds(0.1f);

            animator.SetBool("Atk1", false);
            yield return new WaitForSeconds(0.1f);
            //기다리는동안 일어날 일들
            yield return new WaitForSeconds(3f);

            attackMode = 0;
        }
        if(attackMode == 2)
        {
            xanimator.Atk2();
            Debug.Log("atk2");
            yield return new WaitForSeconds(0.1f);

            animator.SetBool("Atk2", false);
            yield return new WaitForSeconds(0.1f);
            yield return new WaitForSeconds(3f);
            attackMode = 0;
        }
       */
        yield return null;
    }


    void Die()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        animator.Play("Die");
       
        Destroy(this.gameObject, 2.3f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, walkrange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, findrange);
    }

}


//if (nav.destination == null)
//{
//    nav.destination = player.transform.position;
//}
//else
//{
//    nav.destination = player.transform.position;
//}

//nav.SetDestination(player.transform.position);
