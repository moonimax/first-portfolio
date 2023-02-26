using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPortal : MonoBehaviour
{
    public GameObject showBossmessage;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            showBossmessage.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
