using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//會被生成 銷毀 修復 破壞
public class InteractiveObject : MonoBehaviour
{
    public GameManager GameManager;

    public GameObject target;

    public SkillManager SkillManager;
    
    public ObjectData objectData;

    public virtual void Awake()
    {
        UpdateInformation();
    }

    public virtual void Start()
    {
        Initialize();
    }

    public virtual void Update()
    {
        //UNDO 死亡後防止扣血 執行移動或技能

        if (objectData.objectState != ObjectState.Dead)
        {
            HealthRestore(objectData.currentHealth, objectData.currentMaxHealth, objectData.currentHealthRestore);//確保死亡不補血 //不會被攻擊  可回血
            MakeSureHealth();//Combat Dead
            UpdateOutOfCombatTime();
        }
        UpdateUI();
    }

    public virtual void Initialize()
    {

    }

    //Update
    public virtual void UpdateInformation()
    {
        objectData.currentHealth = objectData.maxHealth;
        objectData.currentMaxHealth = objectData.maxHealth;
        objectData.currentHealthRestore = objectData.baseHealthRestore;
        objectData.currentDefense = objectData.baseDefense;
        objectData.currentDamage = objectData.baseDamage;
    }

    public void HealthRestore(float _currentHealth, float currentMaxHealth, float currentHealthRestore)//血量回復
    {
        objectData.currentHealth = _currentHealth + currentMaxHealth * currentHealthRestore / 100 * Time.deltaTime;
    }

    //避免溢出  死亡後切換狀態 呼叫腳色死亡  脫離戰鬥狀態
    public virtual void MakeSureHealth()
    {
        if (objectData.currentHealth >= objectData.maxHealth)
            objectData.currentHealth = objectData.maxHealth;
        else if (objectData.currentHealth <= 0.5f)
        {
            objectData.currentHealth = 0;
            objectData.objectState = ObjectState.Dead;
            IfDead();
            objectData.OutOfCombatTime = 10;
        }
    }

    public void UpdateOutOfCombatTime()
    {
        if (objectData.inBattle)
        {
            objectData.OutOfCombatTime -= Time.deltaTime;
            if (objectData.OutOfCombatTime < 0)
            {
                objectData.inBattle = false;
                objectData.OutOfCombatTime = 10;
            }
        }
    }

    public virtual void IfDead()
    {

    }

    public void UpdateCharacter()//更新資訊
    {
        switch (objectData.objectType)
        {
            case ObjectType.Player:

                break;
            case ObjectType.Monster:

                break;
            case ObjectType.Material:
                break;
        }
        ObjectStateSwitch();
    }

    public void ObjectStateSwitch()
    {
        switch (objectData.objectState)
        {
            case ObjectState.Guard:
                break;
            case ObjectState.Patrol:
                break;
            case ObjectState.Dead:
                break;
        }
        UpdateUI();
    }


    //Calculate
    public void TakeDamage(OrganismData attacker, OrganismData defener)//算出攻擊者的攻擊力減去被攻擊者的防禦後的傷害
    {
        float 恢復量 = CalculatorCritical(attacker) * objectData.variable;// 恢復技能加成

        float damage = Math.Max(attacker.currentDamage * 100 / (defener.currentDefense + 100), 1);//MOBA算法
        defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
        attacker.inBattle = true;
        defener.inBattle = true;
        //defener.acimator.SetTrigger("Hit");
        UpdateCharacter();
        if (attacker.iscritical)
        {
            Debug.Log(attacker.gameObject.name + " 產生爆擊! 攻擊力:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " 剩餘血量: " + defener.currentHealth.ToString("f0"));
            return;
            //defener.GetComponent<Animator>().SetTrigger("Hit");
        }
        Debug.Log(attacker.gameObject.name + " 攻擊力:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " 剩餘血量: " + defener.currentHealth.ToString("f0"));
    }

    public void Heal(OrganismData Healer, OrganismData Healed)
    {
        float recoveryAmount = CalculatorCritical(Healer) * objectData.variable;// 恢復技能加成
        Healed.currentHealth = Math.Min(Healed.currentHealth + recoveryAmount, Healed.currentMaxHealth);
        UpdateCharacter();
        Debug.Log(Healer.gameObject.name + " 對 " + Healed.gameObject.name + " 回復了 " + recoveryAmount.ToString("f0") + "\n剩餘血量: " + Healed.currentHealth.ToString("f0"));
    }

    float CalculatorCritical(OrganismData attacker)
    {
        float random = UnityEngine.Random.value;
        attacker.iscritical = random <= attacker.criticalChance;//亂數小於爆擊率=爆擊
        float currentDamage = attacker.iscritical ? attacker.currentDamage * 2 : attacker.currentDamage;
        return currentDamage;
    }

    public float CurrentValue(OrganismData attacker, float variable)//CalculateRandomDamage
    {
        float random = 0.3f;//隨機傷害範圍
        float currentDamage = attacker.currentDamage * variable;
        currentDamage = UnityEngine.Random.Range(currentDamage - currentDamage * random, currentDamage + currentDamage * random);

        return currentDamage;
    }

    public virtual void UpdateUI()
    {

    }

    //無用
    public void Dead()
    {
        DropLoot();
    }

    public void DropLoot()
    {
        foreach (LootData loot in objectData.lootTable)
        {
            // Generate a random number between 0 and 100.
            int roll = Random.Range(0, 100);

            // If the roll is less than the drop chance, drop the item.
            if (roll < loot.dropChance)
            {
                // Instantiate the item at the current position.
                Instantiate(loot.item, transform.position, Quaternion.identity);
            }
        }
    }

}
