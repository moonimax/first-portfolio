using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemy : MonoBehaviour
{
    public GameObject Orc;
    public int orcnumber;
    public GameObject slime;
    public int slimenumber;

    Vector3 spawnposition;

    private void Update()
    {
        spawnposition = transform.position;
        spawnposition.x = Random.Range(spawnposition.x - 0.05f, spawnposition.x + 0.05f);
        spawnposition.z = Random.Range(spawnposition.z - 0.05f, spawnposition.z + 0.05f);
    }

    private void OnEnable()
    {
       
            for(int i = 0 ; i < orcnumber; i++)
            {
                Instantiate(Orc, transform.position, Quaternion.identity);
            }
            for(int i = 0 ;i < slimenumber; i++)
            {
                Instantiate(slime, transform.position, Quaternion.identity);

            }

        
    }
}
