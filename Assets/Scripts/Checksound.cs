using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checksound : MonoBehaviour
{
   
    void Start()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio1>().Checkscene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
