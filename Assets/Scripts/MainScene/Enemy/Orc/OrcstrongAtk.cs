using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcstrongAtk : MonoBehaviour
{
    float countdown = 0;
    float countdown1 = 0.5f;

    public float strongatk = 7f;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (countdown <= 0)
            {
                other.GetComponent<PlayerStats>().TakeDamage(strongatk);
                countdown = countdown1;
            }
        }
        countdown -= Time.deltaTime;
    }

    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private IEnumerator AutoDisable()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(2.3f);

        gameObject.SetActive(false);

    }
    
}
