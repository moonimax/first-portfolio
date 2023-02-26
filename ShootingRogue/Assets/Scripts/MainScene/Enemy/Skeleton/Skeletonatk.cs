using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletonatk : MonoBehaviour
{
    float skeletonatk = 10f;
    // Start is called before the first frame update
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(skeletonatk);
        }
    }

    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private IEnumerator AutoDisable()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
      
    }

}
