using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStat : MonoBehaviour
{
    public float enemyHealth;
    public float enemyStartHealth = 50;
    public Image enemyhealthBar;
    //�⺻����
    public float enemybaseAtk = 5;

    [HideInInspector]
    public float SmallDragonnormalAtk = 10f;
    [HideInInspector]
    public float SmallDragonstrongAtk = 15f;
    [HideInInspector]
    public float skeletonDefense = 0.1f;
    [HideInInspector]
    public float skeletonDefense1 = 0f;
    void Start()
    {
        enemyHealth = enemyStartHealth;

    }

    // Update is called once per frame
    void Update()
    {
        enemyhealthBar.fillAmount = enemyHealth / enemyStartHealth;
        if(enemyhealthBar.fillAmount < 0.3)
        {
            SetColor();
        }

    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        Debug.Log("���� �ǰ� " + enemyHealth);
    }

    void SetColor()
    {
        enemyhealthBar.color = Color.red;
    }

}

/*
 * enemyHealth -= damage;
        if (enemyHealth <= 0 && !isDead)
        {
            Die();
        }

public void slowSpeed(float pct)
    {
        movespeed = startSpeed * (1f - pct);
    }

    /*
    40% ���� : startSpeed * (1f- 0.4f)
    40% �ӵ� : starrtSpeed * 0.4f

    ���ݷ� 40% ���� : attack * (1f - 0.4f)
    ���ݷ��� 40% ���� : attack * 0.4f
*/



