using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAtk3 : MonoBehaviour
{
    BossAI bossAI;
    private void Start()
    {
        bossAI = GetComponentInParent<BossAI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (bossAI.impact2 == true)
            {
                other.GetComponent<PlayerStats>().TakeDamage(20f + bossAI.attack1);
                return;
            }

            if (bossAI.impact == true)
            {
                other.GetComponent<PlayerStats>().TakeDamage(20f + bossAI.attack2);
                return;
            }
            other.GetComponent<PlayerStats>().TakeDamage(20f);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(disapear());
    }

    IEnumerator disapear()
    {
        yield return new WaitForSeconds(0.01f);
        this.gameObject.SetActive(false);
    }
}
