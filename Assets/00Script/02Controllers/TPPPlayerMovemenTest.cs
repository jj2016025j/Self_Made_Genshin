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
        Debug.Log("�C���}�l�A�ܼƪ�l�Ƨ���");
    }

    void Update()
    {
        MovePlayerOnXZPlane();
        CheckGroundAndClimb();
        ApplyGravity();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            Debug.Log("���a���D");
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
            Debug.Log("���a�bXZ�����W����");
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
        Debug.Log("���a�bY�b�W����(�]�A���O�M���D)");
    }
}
