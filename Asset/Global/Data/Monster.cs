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
        //��q
        maxHealth = 100;
        currentMaxHealth = 100;
        currentHealth = 100;
        //�^�_
        baseHealthRestore = 1;
        currentHealthRestore = 1;
        //���m
        baseDefense = 10;
        currentDefense = 10;

        //����
        baseDamage = 10;
        currentDamage = 10;
        //��L
        attackRange = 10;
        criticalMultiplier = 50;//�z���[��
        criticalChance = 10;//�z�����v
        variable = 1;//Balance
        name = "NO." + Random.Range(0, 100).ToString() + " Slime";
    }
    public override void IfDead()
    {
        MonsterManager.IfDead(this);
    }

}
