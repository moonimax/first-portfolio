using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemy : MonoBehaviour
{

    public GameObject slime;
    public GameObject[] enemies;

    public int enemynumber = 5;

    Vector3 startposition;
    void Start()
    {
    }
    
    private void OnEnable()
    {
        startposition = transform.position;
        startposition.x = Random.Range(transform.position.x - 0.5f, transform.position.x + 0.5f);
        startposition.z = Random.Range(transform.position.z -0.5f, transform.position.z  + 0.5f);
        
        for (int i = 0; i < enemynumber; i++) 
        {
            Instantiate(slime, startposition, Quaternion.identity);
           
        } 
    }
    
}
