using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform : MonoBehaviour
{
    public float a;
    public float b;
    public float c;
    public float d;
    public GameObject player;
    public GameObject[] player2;

    public float speed = 1;
    public float jumpSpeed = 10;
    public float gravity = 20;
    public float margin = 0.1f;
    private Vector3 moveDirection = Vector3.zero;
    // 通過射線檢測主角是否落在地面或者物體上
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, margin);
    }

    void Start()
    {
        c = (float)Math.Pow(2, 0.5);
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (IsGrounded())
        {
            moveDirection = new Vector3(h, 0, v);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            // 空格鍵控制跳躍
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;

        b = Input.GetAxis("Vertical");
        a = Input.GetAxis("Horizontal"); 
        /*if (a! > 0 && b! > 0)
        {
            a = a / c;
            b = b / c;
            transform.Translate(a, 0, b);
        }
        else
        {
            transform.Translate(a, 0, b);
        }*/
    }
}
