using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerbox : MonoBehaviour
{

    public GameObject Makeenemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Makeenemy.SetActive(true);
            StartCoroutine(disapper());
        }
    }

    IEnumerator disapper()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
