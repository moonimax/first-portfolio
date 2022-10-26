using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAI : EnemyAI
{
    Vector3 playerPos;
   
    protected override IEnumerator Attackpattern()
    {
        //메이지는 attack 모드가 하나밖에 없음

            xanimator.Atk1();
            //playerPos = player.transform.position;
       
            //해당 애니메이션을 실행함
            attackMode = 1;
            yield return new WaitForSeconds(0.1f);
            animator.SetBool("Atk1", false);
            yield return new WaitForSeconds(5f);
           
            attackMode = 0;
           
    }

}
