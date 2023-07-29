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

public class EntityData : MonoBehaviour
{
    [Header("Stats Info")]
    public float maxHealth = 100;
    public float currentMaxHealth = 100;
    public float currentHealth = 100;
    public float baseHealthRestore = 1;
    public float currentHealthRestore = 1;
    public float baseDefense = 10;
    public float currentDefense = 10;

    [Header("Damage Info")]
    public float baseDamage = 10;
    public float currentDamage = 10;
    public float attackRange = 3;
    public float skillRange = 30;
    public float coolDown = 0;
    public float criticalMultiplier = 50;
    public float criticalChance = 0;
    public bool iscritical = false;
    public int variable;


    [Header("Other Info")]
    public bool inBattle = false;
    public float OutOfCombatTime = 10;
    public int money;
    public List<LootData> lootTable;
    public List<GameObject> bag;
    public float baseSpeed = 100;
    public float currentSpeed = 100;

    [Header("AI Info")]
    public float patrolRange = 20;
    public float sightRange = 20;

    public ObjectState objectState;
    public ObjectType objectType;
    public GameObject target;

    public virtual void Awake()
    {
        Debug.Log("物件被創建，正在更新數據...");
        UpdateInformation();
    }

    public virtual void Start()
    {
        Debug.Log("物件開始初始化...");
        Initialize();
    }

    public virtual void Update()
    {
        Debug.Log("正在更新物件狀態...");
        UpdateState();
    }

    private void UpdateState()
    {
        if (objectState != ObjectState.Dead)
        {
            HealthRestore(currentHealth, currentMaxHealth, currentHealthRestore);
            MakeSureHealth();
            UpdateOutOfCombatTime();
        }
    }

    public virtual void Initialize()
    {
        Debug.Log("正在初始化物件數值...");
        currentHealth = maxHealth;
        currentMaxHealth = maxHealth;
        currentHealthRestore = baseHealthRestore;
        currentDefense = baseDefense;
        currentDamage = baseDamage;
        currentSpeed = baseSpeed;
    }

    public virtual void UpdateInformation()
    {
        Debug.Log("正在更新物件數據...");
        currentHealth = maxHealth;
        currentMaxHealth = maxHealth;
        currentHealthRestore = baseHealthRestore;
        currentDefense = baseDefense;
        currentDamage = baseDamage;
    }

    public void HealthRestore(float _currentHealth, float currentMaxHealth, float currentHealthRestore)
    {
        Debug.Log("正在回復血量...");
        currentHealth = _currentHealth + currentMaxHealth * currentHealthRestore / 100 * Time.deltaTime;
    }

    public virtual void MakeSureHealth()
    {
        Debug.Log("正在確保血量在合理範圍內...");
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth <= 0.5f)
        {
            currentHealth = 0;
            objectState = ObjectState.Dead;
            Debug.Log("物件已死亡...");
            OutOfCombatTime = 10;
        }
    }

    public void DamageSkill(EntityData attacker, EntityData defener)
    {
        Debug.Log("正在計算傷害...");
        float recoveryAmount = CalculatorCritical(attacker) * currentDamage; // 恢復技能加成
        float damage = Math.Max(attacker.currentDamage * 100 / (defener.currentDefense + 100), 1); // MOBA算法
        defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
        attacker.inBattle = true;
        defener.inBattle = true;
        if (attacker.iscritical)
        {
            Debug.Log(attacker.gameObject.name + " 產生爆擊! 攻擊力:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " 剩餘血量: " + defener.currentHealth.ToString("f0"));
            return;
        }
        Debug.Log(attacker.gameObject.name + " 攻擊力:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " 剩餘血量: " + defener.currentHealth.ToString("f0"));
    }

    public void HealSkill(EntityData Healer, EntityData Healed)
    {
        Debug.Log("正在治療...");
        float recoveryAmount = CalculatorCritical(Healer) * currentDamage; // 恢復技能加成
        Healed.currentHealth = Math.Min(Healed.currentHealth + recoveryAmount, Healed.currentMaxHealth);
        Debug.Log(Healer.gameObject.name + " 對 " + Healed.gameObject.name + " 回復了 " + recoveryAmount.ToString("f0") + "\n剩餘血量: " + Healed.currentHealth.ToString("f0"));
    }

    float CalculatorCritical(EntityData attacker)
    {
        Debug.Log("正在計算是否爆擊...");
        float random = UnityEngine.Random.value;
        attacker.iscritical = random <= attacker.criticalChance; // 亂數小於爆擊率=爆擊
        float currentDamage = attacker.iscritical ? attacker.currentDamage * 2 : attacker.currentDamage;
        return currentDamage;
    }

    public float CalculateRandomDamage(EntityData attacker, float variable)
    {
        Debug.Log("正在計算隨機傷害...");
        float random = 0.3f; // 隨機傷害範圍
        float currentDamage = attacker.currentDamage * variable;
        currentDamage = UnityEngine.Random.Range(currentDamage - currentDamage * random, currentDamage + currentDamage * random);
        return currentDamage;
    }

    public void UpdateOutOfCombatTime()
    {
        Debug.Log("正在更新戰鬥狀態的時間...");
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
}
