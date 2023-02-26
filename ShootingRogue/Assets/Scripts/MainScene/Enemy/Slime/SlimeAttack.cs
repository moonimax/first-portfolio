using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : EnemyAI
{
    protected override IEnumerator Attackpattern()
    {
        attackMode = Random.Range(1, 3);
        if (attackMode == 1)
        {
            xanimator.Atk1();
            
            yield return new WaitForSeconds(0.1f);

            animator.SetBool("Atk1", false);
            yield return new WaitForSeconds(0.1f);
            //기다리는동안 일어날 일들
            yield return new WaitForSeconds(3f);

            attackMode = 0;
        }
        if (attackMode == 2)
        {
            xanimator.Atk2();
           
            yield return new WaitForSeconds(0.1f);

            animator.SetBool("Atk2", false);
            yield return new WaitForSeconds(0.1f);
            yield return new WaitForSeconds(3f);
            attackMode = 0;
        }
    }






}
