using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpForce = 5f;

    public Vector3 moveDirection;

    private CharacterController characterController;

   
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if(characterController.isGrounded == false)
       // {
       //     moveDirection.y += gravity * Time.deltaTime;
       // }

       //characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = new Vector3 (direction.x, moveDirection.y, direction.z);
    } 

    public void JumpTo()
    {
        /*
        if (characterController.isGrounded == false)
        {
            return;
        }
        */
        //¹Ù´Ú ¹â°í ÀÖÀ¸¸é Á¡ÇÁ
       // if (characterController.isGrounded == true)
       // {
           
            moveDirection.y = 0;
            //moveDirection.y += jumpForce;
       // }
        
    }
}
