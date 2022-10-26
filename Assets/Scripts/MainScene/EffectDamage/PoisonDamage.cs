using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDamage : MonoBehaviour
{
    float poisondamage = 30f;
    float countdown = 0;
    float poisoncool = 0.7f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(AutoDisable());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Box")
        {  if (countdown <= 0)
            {
                other.GetComponent<Enemy>().TakeDamage(poisondamage);
                Debug.Log("포이즌데미지가 들어가는중");
                countdown = poisoncool;
            }
            countdown -= Time.deltaTime;
        }
        if(other.tag == "Boss")
        {
            if (countdown <= 0)
            {
                other.GetComponentInParent<BossAI>().TakeDamage(poisondamage);
                Debug.Log("포이즌데미지가 들어가는중");
                countdown = poisoncool;
            }
            countdown -= Time.deltaTime;
        }

        if (other.tag == "Boss2")
        {
            if (countdown <= 0)
            {
                other.GetComponentInParent<KnightBossAI>().TakeDamage(poisondamage);
                Debug.Log("포이즌데미지가 들어가는중");
                countdown = poisoncool;
            }
            countdown -= Time.deltaTime;
        }
    }

    private IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(5f);

        Destroy(gameObject);
    }


}
