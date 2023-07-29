using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public int health;  // 怪物的生命值
    public int attackPower;  // 怪物的攻擊力
    public SceneManager sceneManager;  // 場景管理器

    void Awake()
    {
        // 從場景中找到場景管理器的實例
        sceneManager = FindObjectOfType<SceneManager>();
    }

    //怪物被創建 【移動組件】
    void Start()
    {
        Debug.Log("怪物被【創建】，目前總數：" + sceneManager.Monsters.Count);

        // 获取NavMeshAgent组件
        agent = GetComponent<NavMeshAgent>();

        // 确保获取到NavMeshAgent组件
        Debug.Assert(agent != null, "未找到 NavMeshAgent 组件");

        // 寻找下一个巡逻点
        wanderPoint = RandomWanderPoint();

        // 在控制台输出怪物开始巡逻的信息
        Debug.Log("怪物开始巡逻");
    }

    // 每一幀調用一次 【移動】
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

    // 當怪物受到攻擊
    public void TakeDamage(int damage)
    {
        // 減去傷害值
        health -= damage;
        Debug.Log("怪物受到" + damage + "點傷害，目前生命值：" + health);

        // 如果生命值小於或等於零，則調用Die函數
        if (health <= 0)
        {
            Die();
        }
    }

    // 怪物進行攻擊
    public void Attack()
    {
        // 這裡可以添加怪物進行攻擊時的行為的程式碼
    }

    // 怪物死亡
    public void Die()
    {
        Debug.Log(gameObject.name + " 已經死亡");
        sceneManager.RemoveMonster(gameObject);
        Destroy(gameObject);
    }

    public float wanderRadius;  // 怪物的巡逻半径
    private NavMeshAgent agent;  // NavMeshAgent组件
    private Vector3 wanderPoint;  // 下一个巡逻点

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

    //怪物被銷毀
    void OnDestroy()
    {
        Debug.Log("怪物被【銷毀】，目前總數：" + (sceneManager.Monsters.Count));
    }
}
