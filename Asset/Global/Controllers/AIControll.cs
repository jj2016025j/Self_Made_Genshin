using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//一種怪物移動方式
//逃跑
public class AIControll : MonoBehaviour
{
    public GameObject Player;

    public PlayerManager PlayerManager;
    public MonsterManager MonsterManager;
    public Transform target;

    [Header("Controll")]
    private NavMeshAgent navMeshAgent;

    [Header("Animator")]
    private Animator Animator;

    [Header("State")]
    public bool canAttack;
    public bool canMove;
    public bool canJump;
    public bool isAiControll;
    private bool mIsDead = false;

    [Header("Info")]
    public GameObject[] Item = null;

    //追蹤AI是否移動
    private bool IsNavMeshMoving
    {
        get
        {
            return navMeshAgent.velocity.magnitude > 0.1f;
        }
    }

    public float attackRange = 10.0f;
    public float chaseRange = 30.0f;
    public float speed = 2.0f;
    public float attackSpeed = 0.5f;
    public float EscapeDistance = 4.0f;
    public float radius = 20.0f;

    // Use this for initialization
    public void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
        Animator.SetBool("initialize", IsNavMeshMoving);
    }

    void Update()
    {
        if (isAiControll)
        {
            ResetAttackTiming();
            Detection();
        }
    }

    public void Detection()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        List<Collider> colliderlist = new List<Collider>();
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Player")
            {
                colliderlist.Add(collider);
            }
        }
        if (colliderlist.Count <= 0)
        {
            navMeshAgent.SetDestination(transform.position);
        }
        else
        {
            Collider collider = FindClosestMonster(colliderlist);
            Chase(collider);
        }
    }

    //Reset attack timing
    public void ResetAttackTiming()
    {
        if (!canAttack)
        {
            attackSpeed -= Time.deltaTime;
            if (attackSpeed < 0)
            {
                canAttack = true;
                attackSpeed = 0.5f;
            }
        }
    }

    public void Chase(Collider other)//UNDO晃動 離地後開始亂走
    {
        // Performance optimization than Vector3.Distance()
        float distance = (transform.position - other.transform.position).sqrMagnitude;
        if (distance <= attackRange)
        {
            transform.LookAt(target.transform.position);
            if (canAttack)
            {
                canAttack = !canAttack;
                navMeshAgent.SetDestination(transform.position);
                Animator.SetBool("attack", IsNavMeshMoving);
            }
        }
        else if (distance <= chaseRange)
        {
            navMeshAgent.SetDestination(target.transform.position);
            Animator.SetBool("run", IsNavMeshMoving);
        }
    }

    public void Escape(Collider other)
    {
        if (mIsDead)
            return;

        // Performance optimization than Vector3.Distance()
        float distance = (transform.position - other.transform.position).sqrMagnitude;

        // Run away from player
        if (distance < EscapeDistance)
        {
            // Vector player to me
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            navMeshAgent.SetDestination(newPos);
        }
        Animator.SetBool("walk", IsNavMeshMoving);
    }

    public Collider FindClosestMonster(List<Collider> colliders)//    20230212
    {
        //距離優先  50  100 150
        //UNDO  優先找怪物   次要找生物   最後找物件
        Collider Closeobject = colliders[0];
        float closestDistance = Vector3.Distance(transform.position, colliders[0].transform.position);

        foreach (var _object in colliders)
        {
            float currentDistance = Vector3.Distance(transform.position, _object.transform.position);
            if (currentDistance < closestDistance)
            {
                Closeobject = _object;
                closestDistance = currentDistance;
            }
        }
        return Closeobject;
    }
}
