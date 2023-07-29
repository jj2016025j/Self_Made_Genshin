using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Organism;

public class TheObject : MonoBehaviour
{
    public GameManager GameManager;

    public GameObject target;

    [Header("SKILL")]
    public ChaseSkill chaseSkill;
    public HelfChaseSkill helfChaseSkill;
    public LineSkill lineSkill;
    public DownSkill downSkill;
    public CloseSkill closeSkill;

    [Header("Stats Info")]
    //血量
    public float maxHealth=100;
    public float currentMaxHealth = 100;
    public float currentHealth = 100;
    //回復%
    public float baseHealthRestore = 1;
    public float currentHealthRestore = 1;
    //防禦
    public float baseDefense = 10;
    public float currentDefense = 10;

    [Header("Damage Info")]
    //攻擊
    public float baseDamage = 10;
    public float currentDamage = 10;

    //戰鬥
    public bool inBattle=false;
    public float OutOfCombatTime = 10;

    //其他
    public int money;
    public   List<UnityEngine.GameObject> bag;

    //Balance
    public float variable=1;

    public enum ObjectState { Guard, Patrol, Chase, Dead, Attack };
    public ObjectState objectState;
    public enum ObjectType { Player, Monster, Material, AI };
    public ObjectType objectType;
    
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
        //UNDO 死亡後防止扣寫 執行移動或技能

        if (objectState != ObjectState.Dead)
        {
            HealthRestore(currentHealth, currentMaxHealth, currentHealthRestore);//確保死亡不補血 //不會被攻擊  可回血
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
        currentHealth = maxHealth;
        currentMaxHealth = maxHealth;
        currentHealthRestore = baseHealthRestore;
        currentDefense = baseDefense;
        currentDamage = baseDamage;
    }

    public void HealthRestore(float _currentHealth, float currentMaxHealth, float currentHealthRestore)//血量回復
    {
        currentHealth = _currentHealth + currentMaxHealth * currentHealthRestore / 100 * Time.deltaTime;
    }

    //避免溢出  死亡後切換狀態 呼叫腳色死亡  脫離戰鬥狀態
    public virtual void MakeSureHealth()
    {
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth <= 0.5f)
        {
            currentHealth = 0;
            objectState = ObjectState.Dead;
            IfDead();
            OutOfCombatTime = 10;
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

    public virtual void IfDead()
    {

    }

    public void UpdateCharacter()//更新資訊
    {
        switch (objectType)
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
        switch (objectState)
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
    public void TakeDamage(Organism attacker, Organism defener)//算出攻擊者的攻擊力減去被攻擊者的防禦後的傷害
    {
        float 恢復量 = CalculatorCritical(attacker) * variable;// 恢復技能加成

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

    public void Heal(Organism Healer, Organism Healed)
    {
        float recoveryAmount = CalculatorCritical(Healer) * variable;// 恢復技能加成
        Healed.currentHealth = Math.Min(Healed.currentHealth + recoveryAmount, Healed.currentMaxHealth);
        UpdateCharacter();
        Debug.Log(Healer.gameObject.name + " 對 " + Healed.gameObject.name + " 回復了 " + recoveryAmount.ToString("f0") + "\n剩餘血量: " + Healed.currentHealth.ToString("f0"));
    }

    float CalculatorCritical(Organism attacker)
    {
        float random = UnityEngine.Random.value;
        attacker.iscritical = random <= attacker.criticalChance;//亂數小於爆擊率=爆擊
        float currentDamage = attacker.iscritical ? attacker.currentDamage * 2 : attacker.currentDamage;
        return currentDamage;
    }

    public float CurrentValue(Organism attacker, float variable)//CalculateRandomDamage
    {
        float random = 0.3f;//隨機傷害範圍
        float currentDamage = attacker.currentDamage * variable;
        currentDamage = UnityEngine.Random.Range(currentDamage - currentDamage * random, currentDamage + currentDamage * random);

        return currentDamage;
    }

    public virtual void UpdateUI()
    {

    }
}
