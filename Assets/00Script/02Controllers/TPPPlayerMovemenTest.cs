using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public float climbingDistance = 0.7f;
    public float tureSmoothTime = 0.1f;
    public Vector3 velocity;
    public bool isGrounded;
    public bool isclimbing;

    private float tureSmoothvelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = GameObject.Find("MainCamera").transform;
        groundCheck = GameObject.Find("GroundCheck").transform;
        Debug.Log("遊戲開始，變數初始化完成");
    }

    void Update()
    {
        MovePlayerOnXZPlane();
        CheckGroundAndClimb();
        ApplyGravity();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            Debug.Log("玩家跳躍");
        }
        LimitVelocity();
        MovePlayerOnYAxis();
    }

    void MovePlayerOnXZPlane()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetngle, ref tureSmoothvelocity, tureSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movedir = Quaternion.Euler(0f, targetngle, 0f) * Vector3.forward;
            controller.Move(movedir.normalized * speed * Time.deltaTime * 2);
            Debug.Log("玩家在XZ平面上移動");
        }
    }

    void CheckGroundAndClimb()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isclimbing = Physics.CheckSphere(groundCheck.position, climbingDistance, groundMask);
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
    }

    void Jump()
    {
        if ((isGrounded || isclimbing))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
            isGrounded = false;
            isclimbing = false;
        }
    }

    void LimitVelocity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -4f;
        }
        if (isclimbing && velocity.y < -4)
        {
            velocity.y = -4f;
        }
    }

    void MovePlayerOnYAxis()
    {
        controller.Move(velocity * Time.deltaTime * 2);
        Debug.Log("玩家在Y軸上移動(包括重力和跳躍)");
    }
}
