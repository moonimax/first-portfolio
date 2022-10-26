using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaptertwodfs : MonoBehaviour
{

    public GameObject firsttrigger;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            firsttrigger.SetActive(true);
        }
    }

}
