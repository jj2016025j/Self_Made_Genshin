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
        deadTime = 15;
        currentDeadTime = 0;

        //����
        baseDamage = 10;
        currentDamage = 10;

        //��L
        attackRange = 10;
        criticalMultiplier = 50;//�z���[��
        criticalChance = 10;//�z�����v

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
    
    public void UpdateDeadTime()//�p�⦺�`�ɶ�
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