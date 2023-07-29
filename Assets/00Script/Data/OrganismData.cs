using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

// "Organism" 代表遊戲中的一個生物或角色。
public class OrganismData : ObjectData
{
    [Header("Damage Info")]
    //攻擊範圍、技能範圍、冷卻時間、爆擊加成、爆擊機率
    public float attackRange = 3;
    public float skillRange = 30;
    public float coolDown = 0;
    public float criticalMultiplier = 50;
    public float criticalChance = 0;
    public bool iscritical = false;

    //DeadTime
    public float deadTime;
    public float currentDeadTime;

    [Header("Other Info")]
    //基礎速度和當前速度
    public float baseSpeed = 100;
    public float currentSpeed = 100;

    [Header("AI Info")]
    //巡邏範圍和視野範圍
    public float patrolRange = 20;
    public float sightRange = 20;

    public override void Update()
    {
        base.Update();
        if (objectState == ObjectState.Dead)
        {
            currentHealth = 0;
        }
    }

    public void UpdateOutOfCombatTime()
    {
        if (inBattle)
        {
            OutOfCombatTime -= Time.deltaTime;
            if (OutOfCombatTime < 0)
            {
                inBattle = false;
                OutOfCombatTime = 10;
            }
        }
    }

    //更新資訊，讓當前速度等於基礎速度
    public override void UpdateInformation()
    {
        base.UpdateInformation();
        currentSpeed = baseSpeed;
        Debug.Log("資訊已更新，當前速度設定為基礎速度。");
    }

    //當前狀態
    public void ObjectStateSwitch()
    {
        switch (objectState)
        {
            case ObjectState.Guard:
                break;
            case ObjectState.Patrol:
                break;
            case ObjectState.Dead:
                break;
        }
    }

    //恢復生命值的函數
    public void Restore()
    {
        if (objectState != ObjectState.Dead)
        {
            HealSkill(this, this);
            Debug.Log("生命值已恢復。");
        }
    }


    //定義怪物的技能與行為
    // 以下分別定義了 HelfChaseSkill、ChaseSkill、LineSkill、DownSkill 和 CloseSkill 這五種技能
    /*
    // HelfChaseSkill
    public void HelfChaseSkill()
    {
        if (objectState != ObjectState.Dead)
        {
            //找到最接近的怪物
            target = FindClosestMonster(GameManager.SceneManager.Monsters);
            if (target == null)
            {
                Debug.Log("未找到目標怪物。");
                return;
            }
            var randomDirection = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);
            var helfChaseObject = Instantiate(helfChaseSkill.gameObject, transform.position + new Vector3(0, 2.5f, 0), randomDirection);
            helfChaseObject.GetComponent<HelfChaseSkill>().selfOrganism = this;
            helfChaseObject.GetComponent<HelfChaseSkill>().targetOrganism = target.GetComponent<Organism>();
            Destroy(helfChaseObject, 5);
            Debug.Log("HelfChaseSkill 已執行。");
        }
    }

    // ChaseSkill
    public void ChaseSkill()
    {
        if (objectState != ObjectState.Dead)
        {
            //找到最接近的怪物
            target = FindClosestMonster(GameManager.SceneManager.Monsters);
            if (target == null)
            {
                Debug.Log("未找到目標怪物。");
                return;
            }
            UnityEngine.GameObject gameObject = target != null ? Instantiate(chaseSkill.gameObject, transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity) : null;
            gameObject.GetComponent<ChaseSkill>().selfOrganism = this;
            gameObject.GetComponent<ChaseSkill>().targetOrganism = target.GetComponent<Organism>();
            Destroy(gameObject, 3);
            Debug.Log("ChaseSkill 已執行。");
        }
    }

    // LineSkill
    public void LineSkill()
    {
        if (objectState != ObjectState.Dead)
        {
            UnityEngine.GameObject gameObject = Instantiate(lineSkill.gameObject, transform.position + new Vector3(0, 1.0f, 0) + transform.forward * 1f, transform.rotation);
            gameObject.GetComponent<LineSkill>().selfOrganism = this;

            Destroy(gameObject, 1);
            Debug.Log("LineSkill 已執行。");
        }
    }

    // DownSkill
    public void DownSkill()
    {
        if (objectState != ObjectState.Dead)
        {
            if (GameManager.SceneManager.Monsters == null || GameManager.SceneManager.Monsters.Count == 0)
            {
                Destroy(Instantiate(downSkill.gameObject, transform.position + new Vector3(0, 10, 0), Quaternion.identity), 2);
                Debug.Log("DownSkill 已執行，但找不到怪物。");
                return;
            }
            target = FindClosestMonster(GameManager.SceneManager.Monsters);
            UnityEngine.GameObject gameObject = Instantiate(downSkill.gameObject, target.transform.position + new Vector3(0, 10, 0), Quaternion.identity);
            gameObject.GetComponent<DownSkill>().selfOrganism = this;
            Destroy(gameObject, 2);
            Debug.Log("DownSkill 已執行。");
        }
    }

    // CloseSkill
    public void CloseSkill()
    {
        if (objectState != ObjectState.Dead)
        {
            UnityEngine.GameObject gameObject = Instantiate(closeSkill.gameObject, transform.position, transform.rotation);
            gameObject.GetComponent<CloseSkill>().selfOrganism = this;
            Debug.Log("CloseSkill 已執行。");
        }
    }

    //找到最接近的怪物
    public GameObject FindClosestMonster(List<GameObject> objects)
    {
        GameObject Closeobject = objects[0];
        float closestDistance = Vector3.Distance(transform.position, objects[0].transform.position);

        foreach (var _object in objects)
        {
            float currentDistance = Vector3.Distance(transform.position, _object.transform.position);
            if (currentDistance < closestDistance)
            {
                Closeobject = _object;
                closestDistance = currentDistance;
            }
        }
        Debug.Log("已找到最接近的怪物。");
        return Closeobject;
    }
*/
}
