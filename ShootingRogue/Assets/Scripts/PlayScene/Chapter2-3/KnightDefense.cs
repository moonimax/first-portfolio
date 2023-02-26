using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightDefense : MonoBehaviour
{
    public GameObject defenseParticle;
    private void OnEnable()
    {
        StartCoroutine(disapear());
    }

    IEnumerator disapear()
    {
        defenseParticle.SetActive(true);
        //��������Ʈ
        yield return new WaitForSeconds(3f);
        defenseParticle.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
