using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAI : EnemyAI
{
    protected override IEnumerator Attackpattern()
    {
        attackMode = Random.Range(1, 3);

        if (attackMode == 1)
        {
            xanimator.Atk1();
            yield return new WaitForSeconds(0.3f);

            animator.SetBool("Atk1", false);
            attackMode = 0;
        }

        if (attackMode == 2)
        {
            xanimator.Atk2();
            yield return new WaitForSeconds(0.3f);

            animator.SetBool("Atk2", false);
            yield return new WaitForSeconds(5f);
            attackMode = 0;
        }
    }
}
