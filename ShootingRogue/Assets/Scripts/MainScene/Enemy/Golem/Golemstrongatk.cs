using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golemstrongatk : MonoBehaviour
{
    private GameObject golem;
    public Vector3 position;
   
    float golstrongatk = 20f;

    public GameObject impact;
    private void Start()
    {
        transform.position = gameObject.transform.parent.gameObject.transform.position;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(golstrongatk);
        }
    }

    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private IEnumerator AutoDisable()
    {
        gameObject.SetActive(true);
        GameObject particle = Instantiate(impact, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);

        Destroy(particle);
        gameObject.SetActive(false);

    }
}
