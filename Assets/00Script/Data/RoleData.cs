using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class RoleData : OrganismData
{
    //開始時初始化數值
    public override void Start()
    {
        Initialize();
    }

    //初始化數值
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

    //確保生命值在一定範圍內
    public override void MakeSureHealth()
    {
        base.MakeSureHealth();
        if (currentHealth <= 0.5f)
        {
            currentDeadTime = deadTime;
            Debug.Log("當前生命值過低，需要採取措施。");
        }
    }

    public void Dead()
    {
        //UNDO 選擇復活地點 原地復活或回安全區 或是重新遊戲
        //停止所有動作
        Debug.Log("玩家死亡");
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