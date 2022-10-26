using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [HideInInspector]
    public GameObject onhit;
    [HideInInspector]
    public GameObject onstronghit;
    
    public GameObject magehitbox;
    [HideInInspector]
    public GameObject skeletonhitbox;
    [HideInInspector]
    public GameObject orcnormalhit;
    [HideInInspector]
    public GameObject orcstronghitbox;


    public Transform golem;
    public GameObject golemnormalhitbox;
    public GameObject golemstronghitbox;

    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ongolemnormalatk()
    {
        golemnormalhitbox.SetActive(true);
    }

    public void Ongolemstrongatk()
    {
        golemstronghitbox.SetActive(true);
        //GameObject golemstronghit = Instantiate(golemstronghitbox, golem.transform.position, Quaternion.identity);
    }

    public void Onorcnormalatk()
    {
        orcnormalhit.SetActive(true);
    }

    public void Onorcstrongatk()
    {
        orcstronghitbox.SetActive(true);
    }
    public void OnskeletonAtk()
    {
        skeletonhitbox.SetActive(true);
    }
    public void OnMageAtk()
    {
        magehitbox.SetActive(true);
    }
    public void OnEnemybaseAtk()
    {
        onhit.SetActive(true);
    }

    public void OnEnemystrongAtk()
    {
        onstronghit.SetActive(true);
    }

    public virtual void Idle()
    {
        //animator.Play("IdleNormal");
    }

    public virtual void Sense()
    {
        //animator.SetTrigger("Sense");
    }
    public virtual void Walk()
    {
        //animator.SetTrigger("Walk");
    }

    public virtual void Atk1()
    {
        //animator.SetBool("Atk1",true);
        
    }

    public virtual void Atk2()
    {
       // animator.SetBool("Atk2",true);
    }

}
