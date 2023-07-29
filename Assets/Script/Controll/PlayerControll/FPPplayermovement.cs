using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPplayermovement2 : MonoBehaviour//第一人稱視角
{
    public CharacterController controller;
    public float speed = 7f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;

    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        velocity.y += gravity * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y =-4f;
        }
        
        controller.Move(velocity * Time.deltaTime*2);
    }
    
}
