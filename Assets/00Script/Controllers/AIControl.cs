using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//一種怪物移動方式
//逃跑
public class AIControl : MonoBehaviour
{
    public GameObject Player;

    public PlayerManager PlayerManager;
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
    public UnityEngine.GameObject[] Item = null;

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

    // 初始化
    void Start()
    {
        // 获取NavMeshAgent组件
        navMeshAgent = GetComponent<NavMeshAgent>();

        // 如果agent为null，说明该对象没有NavMeshAgent组件
        if (navMeshAgent == null)
        {
            // 添加一个NavMeshAgent组件
            navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
            Debug.Log("已自动添加 NavMeshAgent 组件");
        }

        // 确保获取到NavMeshAgent组件
        Debug.Assert(navMeshAgent != null, "未找到 NavMeshAgent 组件");

        // 寻找下一个巡逻点
        wanderPoint = RandomWanderPoint();

        // 在控制台输出怪物开始巡逻的信息
        Debug.Log("怪物开始巡逻");
    }

    void Update()
    {
        if (isAiControll)
        {
            ResetAttackTiming();
            TargetDetection();
            if (true)
            {

            }
        }
    }

    public void TargetDetection()
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

    public float wanderRadius;  // 怪物的巡逻半径
    private Vector3 wanderPoint;  // 下一个巡逻点
    /*
    // 初始化
    void Start()
    {
        // 获取NavMeshAgent组件
        agent = GetComponent<NavMeshAgent>();

        // 确保获取到NavMeshAgent组件
        Debug.Assert(agent != null, "未找到 NavMeshAgent 组件");

        // 寻找下一个巡逻点
        wanderPoint = RandomWanderPoint();

        // 在控制台输出怪物开始巡逻的信息
        Debug.Log("怪物开始巡逻");
    }

    // 每帧更新
    void Update()
    {
        // 判断怪物是否已经到达目标位置
        if (Vector3.Distance(transform.position, wanderPoint) < 1f)
        {
            // 寻找下一个巡逻点
            wanderPoint = RandomWanderPoint();

            // 在控制台输出怪物移动到下一个巡逻点的信息
            Debug.Log("怪物移动到下一个巡逻点");
        }

        // 让怪物向巡逻点移动
        agent.SetDestination(wanderPoint);
    }
    建議我控制功能用繼承的方式還是各寫一個還是有甚麼建議的方法?
    像是不同的怪物
    AI控制還是玩家手動等等
*/
    // 获取一个随机的巡逻点
    public Vector3 RandomWanderPoint()
    {
        // 获取一个在怪物周围wanderRadius范围内的随机点
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;

        // 创建一个NavMeshHit变量用于存储结果
        NavMeshHit navHit;

        // 使用NavMesh.SamplePosition方法找到距离randomPoint最近的可行走点
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);

        // 返回找到的点
        return navHit.position;
    }

}
