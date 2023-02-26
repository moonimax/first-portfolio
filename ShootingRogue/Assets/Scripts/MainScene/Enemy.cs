using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyhealth;
    float enemystarthealth = 50;
    void Start()
    {
        enemyhealth = enemystarthealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyhealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        enemyhealth -= damage;
        Debug.Log("적의 체력은:" + enemyhealth);
    }
}
