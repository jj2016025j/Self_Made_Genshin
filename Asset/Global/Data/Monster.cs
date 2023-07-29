using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Monster : Organism
{
    public MonsterManager MonsterManager;
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

        //攻擊
        baseDamage = 10;
        currentDamage = 10;
        //其他
        attackRange = 10;
        criticalMultiplier = 50;//爆擊加成
        criticalChance = 10;//爆擊機率
        variable = 1;//Balance
        name = "NO." + Random.Range(0, 100).ToString() + " Slime";
    }
    public override void IfDead()
    {
        MonsterManager.IfDead(this);
    }

}
