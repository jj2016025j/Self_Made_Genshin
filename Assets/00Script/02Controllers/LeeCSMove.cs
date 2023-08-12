using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController),typeof(PlayerInput))]
public class LeeCSMove : MonoBehaviour
{
    [Header("References")]
    public CharacterController controller;
    public Transform cam;
    public LayerMask groundMask;
    PlayerInput Controller;

    [Header("Movement Parameters")]
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public float climbingDistance = 0.7f;
    public float tureSmoothTime = 0.1f;

    public Vector3 velocity;
    public bool isGrounded;
    public bool isclimbing;
    public float tureSmoothvelocity;

    void Start()
    {
        InitializeComponents();
        Debug.Log("遊戲開始，進行變數初始化");
    }

    void Update()
    {
        CheckGroundAndClimb();
        MovePlayerOnXZPlane();
        HandleJump();
        ApplyGravity();
        LimitVelocity();
        MovePlayerOnYAxis();
    }

    void InitializeComponents()
    {
        controller = GetComponent<CharacterController>();
        cam = GameObject.Find("Main Camera").transform;
    }

    void CheckGroundAndClimb()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, groundDistance, groundMask);
        isclimbing = !isGrounded && Physics.Raycast(transform.position, transform.forward, out hit, climbingDistance, groundMask);
    }

    void MovePlayerOnXZPlane()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        if (direction.sqrMagnitude < 0.1f) return;

        float targetngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetngle, ref tureSmoothvelocity, tureSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 movedir = Quaternion.Euler(0f, targetngle, 0f) * Vector3.forward;
        controller.Move(movedir.normalized * speed * Time.deltaTime);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && (controller.isGrounded || isclimbing))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("玩家進行跳躍操作");
        }
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
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
        controller.Move(velocity * Time.deltaTime);
    }
}
