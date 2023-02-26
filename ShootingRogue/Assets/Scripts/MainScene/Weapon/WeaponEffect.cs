using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEffect : MonoBehaviour
{
    public GameObject poision; 
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    public void poisoneffect(RaycastHit Hit)
    {
        StartCoroutine(Autopoison());
    }
    private IEnumerator Autopoison()
    {
        
        poision.SetActive(true);
        yield return new WaitForSeconds(3f);

        poision.SetActive(false);
    }
}
