using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAI : EnemyAI
{
    Vector3 playerPos;
   
    protected override IEnumerator Attackpattern()
    {
        //�������� attack ��尡 �ϳ��ۿ� ����

            xanimator.Atk1();
            //playerPos = player.transform.position;
       
            //�ش� �ִϸ��̼��� ������
            attackMode = 1;
            yield return new WaitForSeconds(0.1f);
            animator.SetBool("Atk1", false);
            yield return new WaitForSeconds(5f);
           
            attackMode = 0;
           
    }

}
