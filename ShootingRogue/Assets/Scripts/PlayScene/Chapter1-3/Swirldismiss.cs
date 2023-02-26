using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swirldismiss : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(disapear());
    }

    IEnumerator disapear()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
