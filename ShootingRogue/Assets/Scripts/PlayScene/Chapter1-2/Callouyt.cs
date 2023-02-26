using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Callouyt : MonoBehaviour
{
    public GameObject spawnpos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            spawnpos.SetActive(true);
            
        }
    }
    
}
