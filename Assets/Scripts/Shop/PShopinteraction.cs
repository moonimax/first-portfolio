using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PShopinteraction : MonoBehaviour
{
    public GameObject ShopUI;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShopUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShopUI.SetActive(false);
        }
    }
}
