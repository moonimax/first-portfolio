using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDragonStronghit : MonoBehaviour
{
    public GameObject dragonparticle;
    private EnemyStat enemyStat;
    float countdown = 0f;
    float countdown1 = 0.8f;
    float strongatk = 9f;
    private void Start()
    {
        enemyStat = GetComponentInParent<EnemyStat>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (countdown <= 0)
            {
                other.GetComponent<PlayerStats>().TakeDamage(strongatk);
                countdown = countdown1;
            }
            countdown -= Time.deltaTime;
        }
    }

    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private IEnumerator AutoDisable()
    {
        dragonparticle.SetActive(true);
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
        dragonparticle.SetActive(false);
    }
}
