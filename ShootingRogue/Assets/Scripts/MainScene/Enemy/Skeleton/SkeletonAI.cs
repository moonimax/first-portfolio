using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : EnemyAI
{
    
    protected override IEnumerator Attackpattern()
    {
        attackMode = Random.Range(1, 4);

       
        if(attackMode == 1)
        {
            xanimator.Atk1();

            yield return new WaitForSeconds(3f);
            
            animator.SetBool("Atk1", false);
            yield return new WaitForSeconds(0.1f);

            attackMode = 0;

        }

        if(attackMode == 2)
        {
            xanimator.Atk2();

            yield return new WaitForSeconds(3f);

            animator.SetBool("Atk2", false);
            yield return new WaitForSeconds(0.1f);

          
            attackMode = 0;

        }

        if (attackMode == 3)
        {
            animator.SetBool("Defense1", true);
            //enemystat.skeletonDefense;

            yield return new WaitForSeconds(3f);

            animator.SetBool("Defense1", false);
            yield return new WaitForSeconds(0.1f);

            //enemystat.Defense = 0f;
            attackMode = 0;

        }


        yield return null;
    }
}
