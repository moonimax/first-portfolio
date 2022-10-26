using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private float radius = 3f;

    //�÷��̾���� �Ÿ�
    //public Transform player;
    PlayerMove playermove;
    
    public bool hasinteracted = true;

    private void Start()
    {
        playermove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }
    public virtual void Interact()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, playermove.transform.position);
        
        if (distance <= radius)
        {   
            hasinteracted = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!hasinteracted)
                {
                    return;
                }

                Interact();
            }


        }
        if(distance > radius) // �Ÿ��� �ָ� ��ȣ�ۿ� false
        {
            hasinteracted = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
