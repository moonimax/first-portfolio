using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firedamage : MonoBehaviour
{
    float countdown = 0f;

    float firecool = 1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(countdown <= 0)
            {
                other.GetComponent<PlayerStats>().TakeDamage(10f);
                countdown = firecool;
            }
            countdown -= Time.deltaTime;
        }
    }
}
