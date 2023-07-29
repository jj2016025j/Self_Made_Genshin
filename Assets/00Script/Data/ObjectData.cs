using System;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectState
{
    Guard,
    Patrol,
    Chase,
    Dead,
    Attack
};

public enum ObjectType
{
    Player,
    Monster,
    Material,
    AI
};

public class ObjectData : MonoBehaviour
{
    [SerializeField]
    public SkillManager skill;

    public LootData[] lootTable;  // This is the table of potential drops.

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

    public ObjectState objectState;

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
        }
    }
    //初始化
    public virtual void Initialize()
    {
        currentHealth = maxHealth;
        currentMaxHealth = maxHealth;
        currentHealthRestore = baseHealthRestore;
        currentDefense = baseDefense;
        currentDamage = baseDamage;
    }

    //Update
    public virtual void UpdateInformation()
    {
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
        }
    }

    //傷害技能
    public void DamageSkill(OrganismData attacker, OrganismData defener)//算出攻擊者的攻擊力減去被攻擊者的防禦後的傷害
    {
        float 恢復量 = CalculatorCritical(attacker) * variable;// 恢復技能加成

        float damage = Math.Max(attacker.currentDamage * 100 / (defener.currentDefense + 100), 1);//MOBA算法
        defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
        attacker.inBattle = true;
        defener.inBattle = true;
        //defener.acimator.SetTrigger("Hit");
        if (attacker.iscritical)
        {
            Debug.Log(attacker.gameObject.name + " 產生爆擊! 攻擊力:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " 剩餘血量: " + defener.currentHealth.ToString("f0"));
            return;
            //defener.GetComponent<Animator>().SetTrigger("Hit");
        }
        Debug.Log(attacker.gameObject.name + " 攻擊力:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " 剩餘血量: " + defener.currentHealth.ToString("f0"));
    }

    //治癒技能
    public void HealSkill(OrganismData Healer, OrganismData Healed)
    {
        float recoveryAmount = CalculatorCritical(Healer) * variable;// 恢復技能加成
        Healed.currentHealth = Math.Min(Healed.currentHealth + recoveryAmount, Healed.currentMaxHealth);
        Debug.Log(Healer.gameObject.name + " 對 " + Healed.gameObject.name + " 回復了 " + recoveryAmount.ToString("f0") + "\n剩餘血量: " + Healed.currentHealth.ToString("f0"));
    }

    //計算暴擊傷害
    float CalculatorCritical(OrganismData attacker)
    {
        float random = UnityEngine.Random.value;
        attacker.iscritical = random <= attacker.criticalChance;//亂數小於爆擊率=爆擊
        float currentDamage = attacker.iscritical ? attacker.currentDamage * 2 : attacker.currentDamage;
        return currentDamage;
    }

    //計算隨機傷害
    public float CalculateRandomDamage(OrganismData attacker, float variable)//CalculateRandomDamage
    {
        float random = 0.3f;//隨機傷害範圍
        float currentDamage = attacker.currentDamage * variable;
        currentDamage = UnityEngine.Random.Range(currentDamage - currentDamage * random, currentDamage + currentDamage * random);

        return currentDamage;
    }
}
