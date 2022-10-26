using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golemnormal : MonoBehaviour
{
    float golnormalatk = 12f;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(golnormalatk);
        }
    }

    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private IEnumerator AutoDisable()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);

    }
}
