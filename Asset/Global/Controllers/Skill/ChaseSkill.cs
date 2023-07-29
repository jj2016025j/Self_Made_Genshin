using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseSkill : SkillManager
{
    public Transform target; // 目標物件
    public float speed = 30.0f; // 子彈速度
    public float rotationSpeed = 10.0f; // 旋轉速度

    private void Start()
    {
        target = targetOrganism.transform;
    }
    void Update()
    {
        if (target != null)
        {
            // 計算子彈要飛向目標的方向
            Vector3 direction = (target.position - transform.position).normalized;
            // 計算新的位置
            Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
            // 旋轉子彈以面對目標
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            // 更新子彈的位置
            transform.position = newPosition;
        }
        else
        {
            if (!selfOrganism.FindClosestMonster(selfOrganism.GameManager.SceneControll.MapManager.MonsterManagers).transform)
                return;
            target = selfOrganism.FindClosestMonster(selfOrganism.GameManager.SceneControll.MapManager.MonsterManagers).transform;
            //使子弹继续移动
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
