using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureData : EntityData
{
    //DeadTime
    public float deadTime;
    public float currentDeadTime;
    
    public PlayerManager PlayerManager;

    public override void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();
        //血量
        maxHealth = 100;
        currentMaxHealth = 100;
        currentHealth = 100;
        //回復
        baseHealthRestore = 1;
        currentHealthRestore = 1;
        //防禦
        baseDefense = 10;
        currentDefense = 10;
        deadTime = 15;
        currentDeadTime = 0;

        //攻擊
        baseDamage = 10;
        currentDamage = 10;

        //其他
        attackRange = 10;
        criticalMultiplier = 50;//爆擊加成
        criticalChance = 10;//爆擊機率

        variable = 1;//Balance
    }

    public override void Update()
    {
        base.Update();
        if (objectState == ObjectState.Dead)
        {
            currentHealth = 0;
            UpdateDeadTime();
        }
    }

    public override void MakeSureHealth()
    {
        base.MakeSureHealth();
        if (currentHealth <= 0.5f)
        {
            currentDeadTime = deadTime;
        }
    }
    
    public void UpdateDeadTime()//計算死亡時間
    {
        currentDeadTime -= Time.deltaTime;
        if (currentDeadTime <= 0)
        {
            objectState = ObjectState.Guard;
            currentHealth = maxHealth;
            currentDeadTime = deadTime;
        }
    }
}