using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossAI : MonoBehaviour
{
    protected Animator animator;
    protected EnemyAnimator xanimator;
    private NavMeshAgent nav;

    private GameObject player;

    int attackmode = 0;

    public Image bosshealthbar;

    float dist;

    public GameObject firstround;
    public GameObject secondround;

    [HideInInspector]
    public float attack1 = 3f;
    [HideInInspector]
    public float attack2 = 7f;
    [HideInInspector]
    public GameObject lizardAttack;
    [HideInInspector]
    public GameObject Atk1;
    [HideInInspector]
    public GameObject Atk2;
    [HideInInspector]
    public GameObject Atk3;
    [HideInInspector]
    public GameObject ratAttack;
    [HideInInspector]
    public GameObject crabAttack;

    public GameObject bossstartHealth;
    public GameObject bosshealth;

    public float enemyHealth = 30000;
    float startHealth = 30000;

    [HideInInspector]
    public bool impact = false;
    [HideInInspector]
    public bool impact2 = false;

    [HideInInspector]
    public GameObject buildup11;
    [HideInInspector]
    public GameObject buildup22;

    public enum EnemyStates
    {
        Idle,
        Walk,
        Run,
        Attack1,
        Attack2,
        Attack3,
    }

    [SerializeField] EnemyStates enemyStates = EnemyStates.Idle;
    void Start()
    {
        bossstartHealth.GetComponent<Text>().text = startHealth.ToString();
        enemyHealth = startHealth;
        animator = GetComponent<Animator>();

        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        bosshealth.GetComponent<Text>().text = Mathf.Round(enemyHealth).ToString();

        bosshealthbar.fillAmount = enemyHealth / startHealth;
        if (enemyHealth <= 0)
        {
            animator.Play("Die");
            GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>().Chapterfinished = true;
            Debug.Log("3Â÷");
            return;
        }

        if (!impact2)
        {
            if (enemyHealth <= startHealth / 4)
            {
                bosshealth.GetComponent<Text>().color = Color.red;
                //if (impact2 == true) return;
                impact2 = true;
                buildup22.SetActive(true);
                secondround.SetActive(true);
                Debug.Log("2Â÷");
            }
        }

        if (!impact)
        {
            if (enemyHealth <= startHealth / 2)
            {
                //if (impact == true) return;
                impact = true;
                buildup11.SetActive(true);
                firstround.SetActive(true);
                Debug.Log("1Â÷");
            }
        }
        nav.SetDestination(player.transform.position);
        dist = Vector3.Distance(player.transform.position, transform.position);
        UpdateState();
    }

    void UpdateState()
    {
        switch (enemyStates)
        {
            case EnemyStates.Idle:

                nav.speed = 0;

                animator.Play("IdleBattle");

                enemyStates = EnemyStates.Run;


                break;

            case EnemyStates.Walk:

                break;

            case EnemyStates.Run:

                nav.speed = 3f;
                animator.SetTrigger("Run");

                if (dist <= 8)
                {
                    enemyStates = EnemyStates.Attack1;
                }

                if (dist > 8 && dist <= 10)
                {
                    enemyStates = EnemyStates.Attack2;
                }

                if (dist > 10 && dist < 12f)
                {
                    enemyStates = EnemyStates.Attack3;
                }

                break;

            case EnemyStates.Attack1:
                StartCoroutine(Attak1());

                break;

            case EnemyStates.Attack2:
                StartCoroutine(Attak2());
                break;

            case EnemyStates.Attack3:
                StartCoroutine(Attak3());
                break;
        }


    }

    IEnumerator Attak1()
    {
        if (attackmode == 0)
        {
            nav.speed = 0f;
            attackmode = Random.Range(1, 5);
            if (attackmode == 1)
            {
                nav.speed = 1f;
                animator.SetBool("Attack1", true);
                yield return new WaitForSeconds(1.1f);

                nav.speed = 0f;
                animator.SetBool("Attack1", false);

                yield return new WaitForSeconds(1f);
                attackmode = 0;

                enemyStates = EnemyStates.Idle;
            }

            if (attackmode == 2)
            {
                nav.speed = 1f;
                animator.SetBool("Attack3", true);
                yield return new WaitForSeconds(2f);

                nav.speed = 0f;
                animator.SetBool("Attack3", false);

                yield return new WaitForSeconds(1f);
                attackmode = 0;

                enemyStates = EnemyStates.Run;
            }

            if (attackmode == 3)
            {
                nav.speed = 1f;
                animator.SetBool("LizardAtk", true);

                yield return new WaitForSeconds(0.5f);

                nav.speed = 0f;
                animator.SetBool("LizardAtk", false);
                yield return new WaitForSeconds(0.1f);
                yield return new WaitForSeconds(0.7f);
                attackmode = 0;
                enemyStates = EnemyStates.Idle;
            }

            if (attackmode == 4)
            {
                nav.speed = 1f;
                animator.SetBool("RatAtk", true);

                yield return new WaitForSeconds(0.7f);

                nav.speed = 0f;
                animator.SetBool("RatAtk", false);
                yield return new WaitForSeconds(0.7f);

                attackmode = 0;
                enemyStates = EnemyStates.Run;
            }
        }
    }

    IEnumerator Attak2()
    {
        if (attackmode == 0)
        {
            nav.speed = 0f;
            attackmode = Random.Range(1, 2);
            if (attackmode == 1)
            {
                nav.speed = 1.8f;
                animator.SetBool("CrabAtk", true);
                yield return new WaitForSeconds(1.2f);

                animator.SetBool("CrabAtk", false);
                nav.speed = 0;
                yield return new WaitForSeconds(0.5f);
                attackmode = 0;

                enemyStates = EnemyStates.Run;

            }

        }

    }

    IEnumerator Attak3()
    {
        if (attackmode == 0)
        {
            nav.speed = 0f;
            attackmode = Random.Range(1, 2);
            if (attackmode == 1)
            {
                nav.speed = 2.3f;
                animator.SetBool("Attack2", true);
                yield return new WaitForSeconds(1.1f);

                animator.SetBool("Attack2", false);
                nav.speed = 0;
                yield return new WaitForSeconds(0.5f);
                attackmode = 0;

                enemyStates = EnemyStates.Idle;

            }

        }


    }


    public void TakeDamage(float _damage)
    {
        enemyHealth -= _damage;
    }

    public void lizardAtk()
    {
        lizardAttack.SetActive(true);
    }

    public void Atk11()
    {
        Atk1.SetActive(true);
    }

    public void Atk22()
    {
        Atk2.SetActive(true);
    }

    public void Atk33()
    {
        Atk3.SetActive(true);
    }

    public void ratAtk()
    {
        ratAttack.SetActive(true);
    }

    public void crabattack()
    {
        crabAttack.SetActive(true);
    }

}







/*
 *  Vector3 dir = target.transform.position - partToRotate.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Quaternion targetRotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
        Vector3 eulerRotation = targetRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, eulerRotation.y, 0f);
*
*/



/*
 * 
 *  case EnemyStates.Ready:

                Debug.Log((int)EnemyStates.Ready);
                int rand = Random.Range(0, 5);
                enemyState = (EnemyStates)rand;
                break;

            case EnemyStates.Pattern1:
                Debug.Log((int)EnemyStates.Pattern1);
                int rand2 = Random.Range(1, 5);
                enemyState = (EnemyStates)rand2;
                break;

            case EnemyStates.Pattern2:
                Debug.Log((int)EnemyStates.Pattern2);
                int rand3 = Random.Range(1, 5);
                enemyState = (EnemyStates)rand3;
                break;

            case EnemyStates.Pattern3:
                Debug.Log((int)EnemyStates.Pattern3);
                int rand4 = Random.Range(1, 5);
                enemyState = (EnemyStates)rand4;
                break;

            case EnemyStates.Pattern4:
                Debug.Log((int)EnemyStates.Pattern4);
                int rand5 = Random.Range(1, 5);
                enemyState = (EnemyStates)rand5;
                break;
*/