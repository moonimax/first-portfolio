using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    float knifeAtk = 25f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStat>().TakeDamage(knifeAtk + PlayerStats.Instance.playeratk);
        }
        if (other.CompareTag("Box"))
        {
            other.GetComponent<Enemybox>().TakeDamage(knifeAtk + PlayerStats.Instance.playeratk);
        }
        if (other.CompareTag("Boss"))
        {
            other.GetComponentInParent<BossAI>().TakeDamage(knifeAtk + PlayerStats.Instance.playeratk);
        }
        if (other.CompareTag("Boss2"))
        {
            other.GetComponentInParent<KnightBossAI>().TakeDamage(knifeAtk + PlayerStats.Instance.playeratk);
        }
    }

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Dagger();
        StartCoroutine(AutoDisable());
    }

    private IEnumerator AutoDisable()
    {

        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
