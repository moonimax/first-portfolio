using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orcnormal : MonoBehaviour
{
    public float orcnormalatk = 9f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(orcnormalatk);
        }
    }

    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private IEnumerator AutoDisable()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);

    }
}
