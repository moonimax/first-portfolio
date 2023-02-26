using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class KnightBossAI : MonoBehaviour
{
    protected Animator animator;
    protected EnemyAnimator xanimator;
    private NavMeshAgent nav;

    private GameObject player;

    int attackmode = 0;

    float dist;

    public float enemyHealth = 30000;
    float startHealth = 40000;
    float def;

    float def1 = 0.9f;
    float def2 = 0.8f;
    float def3 = 0.65f;

    bool impact = false;
    bool impact2 = false;
    bool impact3 = false;


    public GameObject firstround;
    public GameObject secondround;
    public GameObject thirdround;


    public GameObject disappear;
    public GameObject stage2;

    public Image bosshealthbar;

    public GameObject bossstartHealth;
    public GameObject bosshealth;

    [HideInInspector]
    public GameObject knightatk1;
    [HideInInspector]
    public GameObject knightatk2;
    [HideInInspector]
    public GameObject knightatk3;
    [HideInInspector]
    public GameObject knightdefense;

    [HideInInspector]
    public GameObject buildup11;
    [HideInInspector]
    public GameObject buildup22;
    [HideInInspector]
    public GameObject powerup11;
    [HideInInspector]
    public GameObject powerup22;
    [HideInInspector]
    public ParticleSystem buildup1;
    [HideInInspector]
    public ParticleSystem powerup1;
    [HideInInspector]
    public ParticleSystem buildup2;
    [HideInInspector]
    public ParticleSystem powerup2;

    private EnemyStates enemyStates = EnemyStates.Idle;

    public enum EnemyStates
    {
        Idle,
        Run,
        Defense,
        Attack1,
        Attack2,
    }

    void Start()
    {
        bossstartHealth.GetComponent<Text>().text = startHealth.ToString();
        gameObject.SetActive(false);
        enemyHealth = startHealth;
        //처음에는 방어력이 0.9임
        def = def1;
        animator = GetComponent<Animator>();

        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        bosshealth.GetComponent<Text>().text = Mathf.Round(enemyHealth).ToString();

        bosshealthbar.fillAmount = enemyHealth / startHealth;
        //피가 2분의 1

        if (enemyHealth <= 0)
        {
            animator.Play("Die");
            GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>().Chapterfinished = true;
            return;
        }



        if (impact3 == false)
            if (enemyHealth <= startHealth / 2)
            {


                impact3 = true;
                disappear.SetActive(false);
                stage2.SetActive(true);
                secondround.SetActive(true);


            }

        if (impact2 == false)
            if (enemyHealth <= startHealth / 3)
            {
                bosshealth.GetComponent<Text>().color = Color.yellow;

                impact2 = true;
                buildup22.SetActive(true);
                //buildup2.Play();
                powerup22.SetActive(true);
                //powerup2.Play();
                def = def3;
                thirdround.SetActive(true);

            }

        if (impact == false)
            if (enemyHealth <= (startHealth / 3) * 2)
            {


                impact = true;
                buildup11.SetActive(true);

                //buildup1.Play();
                powerup11.SetActive(true);
                //powerup1.Play();
                def = def2;
                firstround.SetActive(true);

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

            case EnemyStates.Run:

                nav.speed = 4f;
                animator.SetTrigger("Run");

                if (dist <= 10 && dist > 8)
                {
                    enemyStates = EnemyStates.Defense;
                }

                if (dist <= 8)
                {
                    enemyStates = EnemyStates.Attack1;
                }

                if(dist > 10 && dist <= 12)
                {
                    enemyStates = EnemyStates.Attack1;
                }

                if (dist > 13 && dist <= 14)
                {
                    enemyStates = EnemyStates.Defense;
                }

                break;

            case EnemyStates.Attack1:
                Attack();
                break;

            case EnemyStates.Defense:
                Defense();
                break;
        }
    }

    void Defense()
    {
        StartCoroutine(defensemode());
    }

    IEnumerator defensemode()
    {
        if (attackmode == 0)
        {
            nav.speed = 0;
            attackmode = Random.Range(1, 4);

            if (attackmode == 1 || attackmode == 2)
            {
                nav.speed = 2;
                //그냥 가만히 있다가 돌아간다
                yield return new WaitForSeconds(1f);

                attackmode = 0;
                enemyStates = EnemyStates.Run;
            }

            if (attackmode == 3)
            {
                nav.speed = 0f;

                animator.SetBool("Defense", true);

                yield return new WaitForSeconds(3f);

                animator.SetBool("Defense", false);

                attackmode = 0;
                enemyStates = EnemyStates.Run;
            }

        }
    }




    void Attack()
    {
        StartCoroutine(attack1());
    }

    IEnumerator attack1()
    {
        if (attackmode == 0)
        {
            nav.speed = 0;
            attackmode = Random.Range(1, 4);
            {
                if (attackmode == 1)
                {
                    nav.speed = 1f;
                    animator.SetBool("Atk1", true);
                    yield return new WaitForSeconds(0.35f);

                    animator.SetBool("Atk1", false);

                    yield return new WaitForSeconds(0.5f);

                    attackmode = 0;
                    enemyStates = EnemyStates.Run;
                }
                if (attackmode == 2)
                {
                    nav.speed = 1f;
                    animator.SetBool("Atk2", true);
                    yield return new WaitForSeconds(1.2f);

                    animator.SetBool("Atk2", false);

                    yield return new WaitForSeconds(0.5f);
                    attackmode = 0;
                    enemyStates = EnemyStates.Run;

                }
                if (attackmode == 3)
                {
                    nav.speed = 0f;
                    animator.SetBool("Atk3", true);
                    yield return new WaitForSeconds(1.25f);

                    animator.SetBool("Atk3", false);

                    yield return new WaitForSeconds(0.5f);
                    attackmode = 0;
                    enemyStates = EnemyStates.Run;

                }

            }

        }
    }

    public void TakeDamage(float _damage)
    {
        enemyHealth -= _damage * def;
    }

    public void knightAtk1()
    {

        knightatk1.SetActive(true);
    }

    public void knightAtk2()
    {

        knightatk2.SetActive(true);
    }

    public void knightAtk3()
    {

        knightatk3.SetActive(true);
    }

    public void KnightDefense()
    {
        knightdefense.SetActive(true);
    }
}
