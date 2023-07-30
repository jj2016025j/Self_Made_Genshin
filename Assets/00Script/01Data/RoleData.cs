using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class RoleData : EntityData
{
    //�}�l�ɪ�l�Ƽƭ�
    public override void Start()
    {
        Initialize();
    }

    //��l�Ƽƭ�
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

//UNDO
    //�T�O�ͩR�Ȧb�@�w�d��
    public override void MakeSureHealth()
    {
        base.MakeSureHealth();
        if (currentHealth <= 0.5f)
        {
            currentDeadTime = deadTime;
            Debug.Log("���e�ͩR�ȹL�C�A�ݭn�Ĩ����I�C");
        }
    }

    public void Dead()
    {
        //UNDO ��ܴ_���a�I ��a�_���Φ^�w���� �άO���s�C��
        //����Ҧ��ʧ@
        Debug.Log("���a���`");
    }
}