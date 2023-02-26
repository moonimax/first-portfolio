using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void pistolOnMovement(float horizontal, float vertical)
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }

    public void KnifeMovement(float horizontal, float vertical)
    {
        animator.SetFloat("Knifehorizontal", horizontal);
        animator.SetFloat("Knifevertical", vertical);
    }
    public void KnifeOn()
    {

        animator.SetTrigger("Knife");
    }
    public void Knifeuse()
    {
        animator.SetTrigger("useKnife");
    }
    public void pistolOn()
    {
     
        animator.SetTrigger("Handgun");
    }
    public void pistolshoot()
    {
        animator.SetTrigger("pistolshoot");
    }

    public void assaultOnMovement(float horizontal, float vertical)
    {
        animator.SetFloat("assaulthorizontal", horizontal);
        animator.SetFloat("assaultvertical", vertical);
    }
    public void assaultOn()
    {
        //animator.SetBool("Handgun", false);
        animator.SetTrigger("AssaultRifle");
    }  
    public void assaultshoot()
    {
        animator.SetTrigger("RifleShot");
    }


    public void baseOnMovement(float horizontal, float vertical)
    {
        animator.SetFloat("basehorizontal", horizontal);
        animator.SetFloat("basevertical", vertical);
    }
    public void baseOn()
    {
        animator.SetTrigger("basemovement");
    }
    public void OnJump()
    {
        animator.SetTrigger("Jump");
    }

    public void OnDodge()
    {
        animator.SetTrigger("Dodge");
    }

    public void onpReload()
    {
        animator.SetTrigger("pReload");
    }

    public void onrReload()
    {
        animator.SetTrigger("rReload");
    }
    public void OnShoot()
    {

    }
}
