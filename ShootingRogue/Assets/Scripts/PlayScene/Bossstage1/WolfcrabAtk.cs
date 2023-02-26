using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfcrabAtk : MonoBehaviour
{
    BossAI bossAI;

    public GameObject swirl;
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
                other.GetComponent<PlayerStats>().TakeDamage(10f + bossAI.attack1);
                return;
            }

            if (bossAI.impact == true)
            {
                other.GetComponent<PlayerStats>().TakeDamage(10f + bossAI.attack2);
                return;
            }
                other.GetComponent<PlayerStats>().TakeDamage(10f);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(disapear());
    }

    IEnumerator disapear()
    {
        swirl.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        this.gameObject.SetActive(false);
    }
}
