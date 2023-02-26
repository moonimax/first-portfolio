using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crackparticle : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(disappear());
    }

    IEnumerator disappear()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
