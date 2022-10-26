using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybox : MonoBehaviour
{
    public GameObject slime;

    public bool justbox;

    public bool haskey;
    public GameObject key;
    bool isspawned = false;
    public float boxHealth;
    float startboxhealth = 300;
    void Start()
    {
        boxHealth = startboxhealth;
    }

   
    void Update()
    {
        if (boxHealth <= 0)
        {
            if(justbox == true)
            {
                if(haskey == true)
                {
                    key.SetActive(true);
                }
                Destroy(gameObject, 0.2f);
            }
            if (isspawned == false)
            {
                isspawned = true;
                StartCoroutine(spawnEnemies());
                for (int i = 0; i < 10; i++)
                {
                    GameObject something = Instantiate(slime, transform.position, transform.rotation);
                }
            }
        }
    }

    IEnumerator spawnEnemies()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    public void TakeDamage(float _damage)
    {
        boxHealth -= _damage;
        Debug.Log("박스 데미지가 넘어오는중");
    }
}
