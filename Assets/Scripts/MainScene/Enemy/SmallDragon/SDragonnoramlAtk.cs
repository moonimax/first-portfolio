using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDragonnoramlAtk : MonoBehaviour
{
    private EnemyStat enemyStat;
    float normalatk = 5f;
    private void Start()
    {
        enemyStat = GetComponentInParent<EnemyStat>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(normalatk);
            
        }

    } 
    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private IEnumerator AutoDisable()
    {
       yield return new WaitForSeconds(0.3f);

       gameObject.SetActive(false);
    }
}
