using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAtk2 : MonoBehaviour
{
    public GameObject crackParticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(50f);
        }
    }
    private void OnEnable()
    {
        StartCoroutine(disapear());
    }

    IEnumerator disapear()
    {
        
        crackParticle.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        this.gameObject.SetActive(false);
    }
}
