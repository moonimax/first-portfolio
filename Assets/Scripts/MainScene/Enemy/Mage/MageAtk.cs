using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAtk : MonoBehaviour
{
    GameObject player;
    //[SerializeField]
    //MageAI mageAi;

    float mageAtk = 10f;

    float countdown = 0;
    float countdown1 = 0.7f;
    void Start()
    {
      //  mageAi = GetComponentInParent<MageAI>();
    }

   
    void Update()
    {
    }
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position;
        StartCoroutine(OnAutoDisable());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(countdown <= 0)
            {
                //피격판정
                other.GetComponent<PlayerStats>().TakeDamage(mageAtk);
                countdown = countdown1;

            }
            countdown -= Time.deltaTime;
        }
    }


    private IEnumerator OnAutoDisable()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        
       gameObject.SetActive(false);
    }
}
