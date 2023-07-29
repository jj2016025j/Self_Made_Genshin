using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class Organism : TheObject
{
    [Header("Damage Info")]
    //其他
    public float attackRange=3;
    public float skillRange=30;
    public float coolDown=0;
    public float criticalMultiplier=50;//爆擊加成
    public float criticalChance=0;//爆擊機率
    public bool iscritical=false;

    [Header("Other Info")]
    //速度
    public float baseSpeed = 100;
    public float currentSpeed = 100;

    [Header("AI Info")]
    //偵測範圍
    public float patrolRange = 20;
    public float sightRange = 20;

    public override void UpdateInformation()
    {
        base.UpdateInformation();
        currentSpeed = baseSpeed;
    }

    public override void MakeSureHealth()
    {
        base.MakeSureHealth();
        if (currentHealth <= 0.5f)
        {
        }
    }

    //Active
    public void Restore()
    {
        if (objectState != ObjectState.Dead)
            Heal(this, this);
    }

    public void HelfChaseSkill()//HelfChaseSkill
    {
        if (objectState != ObjectState.Dead)
        {
            target = FindClosestMonster(GameManager.SceneControll.MapManager.MonsterManagers);
            if (target == null)
            {
                return;
            }
            var randomDirection = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);
            var helfChaseObject = Instantiate(helfChaseSkill.gameObject, transform.position + new Vector3(0, 2.5f, 0), randomDirection);
            helfChaseObject.GetComponent<HelfChaseSkill>().selfOrganism = this;
            helfChaseObject.GetComponent<HelfChaseSkill>().targetOrganism = target.GetComponent<Organism>();
            Destroy(helfChaseObject, 5);
        }
    }

    public void ChaseSkill()//ChaseSkill
    {
        if (objectState != ObjectState.Dead)
        {
            target = FindClosestMonster(GameManager.SceneControll.MapManager.MonsterManagers);
            if (target == null)
            {
                return;
            }
            GameObject gameObject = target != null ? Instantiate(chaseSkill.gameObject, transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity) : null;
            gameObject.GetComponent<ChaseSkill>().selfOrganism = this;
            gameObject.GetComponent<ChaseSkill>().targetOrganism = target.GetComponent<Organism>();
            Destroy(gameObject, 3);
        }
    }

    public void LineSkill()//LineSkill  20230212
    {
        if (objectState != ObjectState.Dead)
        {
            GameObject gameObject = Instantiate(lineSkill.gameObject, transform.position + new Vector3(0, 1.0f, 0) + transform.forward * 1f, transform.rotation);
            gameObject.GetComponent<LineSkill>().selfOrganism = this;

            Destroy(gameObject, 1);
        }
    }

    public void DownSkill()//DownSkill  20230212
    {
        if (objectState != ObjectState.Dead)
        {
            if (GameManager.SceneControll.MapManager.MonsterManagers == null || GameManager.SceneControll.MapManager.MonsterManagers.Count == 0)
            {
                Destroy(Instantiate(downSkill.gameObject, transform.position + new Vector3(0, 10, 0), Quaternion.identity),2);
                return;
            }
            target = FindClosestMonster(GameManager.SceneControll.MapManager.MonsterManagers);
            GameObject gameObject =Instantiate(downSkill.gameObject, target.transform.position + new Vector3(0,10,0), Quaternion.identity);
            gameObject.GetComponent<DownSkill>().selfOrganism = this;
            Destroy(gameObject, 2);
        }
    }

    public void CloseSkill()//Close     20230212
    {
        //UNDO ChaseSkill
        if (objectState != ObjectState.Dead)
        {
            GameObject gameObject = Instantiate(closeSkill.gameObject, transform.position, transform.rotation);
            gameObject.GetComponent<CloseSkill>().selfOrganism = this;
        }
    }

    public GameObject FindClosestMonster(List<GameObject> objects)//    20230212
    {
        //距離優先  50  100 150
        //UNDO  優先找怪物   次要找生物   最後找物件
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
        return Closeobject;
    }
}
