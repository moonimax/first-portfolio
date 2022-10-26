using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDragonanimation : EnemyAnimator
{
    public override void Idle()
    {
        animator.Play("IdleNormal");
    }
    public override void Sense()
    {
        animator.SetTrigger("Sense");
    }
    public override void Walk()
    {
        animator.SetTrigger("Walk");
    }
    public override void Atk1()
    {
       animator.SetBool("Atk1", true);
    }
    public override void Atk2()
    {
        animator.SetBool("Atk2", true);
    }
}
