using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemybaseAttackCollision : MonoBehaviour
{
    private EnemyStat enemyStat;

    public float normalatk = 3f;
    private void Start()
    {
        enemyStat = GetComponentInParent<EnemyStat>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(normalatk);
            Debug.Log("ÇÇ°Ý");
            
        }
    }

    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
    }
}
