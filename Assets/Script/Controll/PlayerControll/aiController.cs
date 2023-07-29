using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiController : MonoBehaviour
{
    [Header("Object Script")]
    public List<characterStats> targets;
    public characterStats target;
    public characterStats own;
    public NavMeshAgent navMeshAgent;
    public LayerMask GroundLayer, PlayerLayer;
    public playerManager2 playerManager;
    [Header("Numerical Value")]
    public float sightRange;
    public float attackRange;
    public float patrolRange;//巡邏範圍
    public bool targetInSightRange;
    public bool targetInAttackRange;
    public bool canAttack = true;
    public Vector3 walkPoint;
    public bool walkPointIsSet = false;
    public float TimeToWaitAttack;


    [Header("相機 控制")]
    public CharacterController controller;
    public Transform cam;//相機
    public float tureSmoothTime = 0.1f;
    public float tureSmoothvelocity;
    [Header("玩家 狀態")]
    public float moveSpeed = 5f;//跑速  /100*5
    public float gravity = -9.81f;//重力
    public float jumpForce = 3f;//跳躍力  /100*3
    public float rotationSpeed = 1f;//跳躍力  /100*3
    public bool 可控制的;


    [Header("落地 判斷")]
    public float groundDistance = 0.4f;//觸發距離
    public float climbingDistance = 0.7f;
    public Transform groundCheck;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;
    public bool isclimbing;

    [Header("動畫 控制")]
    public Animator animator;

    private void Awake()
    {
        targets = playerManager.targets;
        target = playerManager.target;
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerManager = GetComponent<playerManager2>();
        controller = GetComponent<CharacterController>();
        GetSpeed();
    }
    void Update()
    {
            //animator.SetFloat("Speed", navMeshAgent.velocity.sqrMagnitude);
            if (Vector3.Distance(target.transform.position, transform.position) >= sightRange) Patroling();
            else if (Vector3.Distance(target.transform.position, transform.position) < sightRange) Chasing();
            else if (Vector3.Distance(target.transform.position, transform.position) < attackRange) Attacking();
    }
    public void GetSpeed()
    {
        if (own)
        {
            moveSpeed = own.speed / 100 * 5;
            jumpForce = own.speed / 100 * 3;
        }
    }

    private void Patroling()
    {
        if (!walkPointIsSet)
        {
            SetWalkPoint();
            walkPointIsSet = true;
        }
        if ((walkPoint - transform.position).magnitude < attackRange)
        {
            SetWalkPoint();
        }
        navMeshAgent.SetDestination(walkPoint);
    }
    private void Chasing()
    {
        navMeshAgent.SetDestination(target.transform.position);
        if ((target.transform.position - transform.position).magnitude < attackRange) Attacking();
    }
    private void Attacking()
    {
        navMeshAgent.SetDestination(transform.position);
        if (canAttack)
        {
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
            playerManager.directionalSkills();
            canAttack = false;
            Invoke(nameof(ResetAttack), 1 / transform.GetComponent<characterStats>().attackSpeed);
        }
    }
    private void ResetAttack()
    {
        canAttack = true;
    }
		private void SetWalkPoint()
    {
        float randomX = Random.Range(-patrolRange, patrolRange);
        float randomZ = Random.Range(-patrolRange, patrolRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        walkPoint = NavMesh.SamplePosition(walkPoint, out NavMeshHit hit, 100, 1) ? hit.position : transform.position;
    }}