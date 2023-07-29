using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureManager : EntityManager
{
    public NavMeshAgent agent; // 用於控制生物移動的NavMeshAgent組件
    public float wanderRadius;  // 生物的巡邏半徑
    private Vector3 wanderPoint;  // 下一個巡邏點

    // 在生物被創建時調用
    public override void Start()
    {
        base.Start();

        // 獲取NavMeshAgent組件
        agent = GetComponent<NavMeshAgent>();

        // 確保獲取到NavMeshAgent組件
        Debug.Assert(agent != null, "未找到 NavMeshAgent 組件");

        // 尋找下一個巡邏點
        wanderPoint = RandomWanderPoint();

        // 在控制台輸出生物開始巡邏的信息
        Debug.Log("生物開始巡邏");
    }

    // 每一幀調用一次
    public override void Update()
    {
        base.Update();
        Patrol();
    }

    // 巡邏方法
    private void Patrol()
    {
        // 判斷生物是否已經到達目標位置
        if (Vector3.Distance(transform.position, wanderPoint) < 1f)
        {
            // 尋找下一個巡邏點
            wanderPoint = RandomWanderPoint();

            // 在控制台輸出生物移動到下一個巡邏點的信息
            Debug.Log("生物移動到下一個巡邏點");
        }

        // 讓生物向巡邏點移動
        agent.SetDestination(wanderPoint);
    }

    // 獲取一個隨機的巡邏點
    public Vector3 RandomWanderPoint()
    {
        // 獲取一個在生物周圍wanderRadius範圍內的隨機點
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;

        // 創建一個NavMeshHit變量用於存儲結果
        NavMeshHit navHit;

        // 使用NavMesh.SamplePosition方法找到距離randomPoint最近的可行走點
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);

        // 返回找到的點
        return navHit.position;
    }

    // 生物死亡
    public void Die()
    {
        // 播放死亡動畫
        // Destroy(gameObject);
        Debug.Log("生物死亡，將播放死亡動畫");
    }
}
