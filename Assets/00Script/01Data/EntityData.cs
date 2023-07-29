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
        Debug.Log("����Q�ЫءA���b��s�ƾ�...");
        UpdateInformation();
    }

    public virtual void Start()
    {
        Debug.Log("����}�l��l��...");
        Initialize();
    }

    public virtual void Update()
    {
        Debug.Log("���b��s���󪬺A...");
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
        Debug.Log("���b��l�ƪ���ƭ�...");
        currentHealth = maxHealth;
        currentMaxHealth = maxHealth;
        currentHealthRestore = baseHealthRestore;
        currentDefense = baseDefense;
        currentDamage = baseDamage;
        currentSpeed = baseSpeed;
    }

    public virtual void UpdateInformation()
    {
        Debug.Log("���b��s����ƾ�...");
        currentHealth = maxHealth;
        currentMaxHealth = maxHealth;
        currentHealthRestore = baseHealthRestore;
        currentDefense = baseDefense;
        currentDamage = baseDamage;
    }

    public void HealthRestore(float _currentHealth, float currentMaxHealth, float currentHealthRestore)
    {
        Debug.Log("���b�^�_��q...");
        currentHealth = _currentHealth + currentMaxHealth * currentHealthRestore / 100 * Time.deltaTime;
    }

    public virtual void MakeSureHealth()
    {
        Debug.Log("���b�T�O��q�b�X�z�d��...");
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth <= 0.5f)
        {
            currentHealth = 0;
            objectState = ObjectState.Dead;
            Debug.Log("����w���`...");
            OutOfCombatTime = 10;
        }
    }

    public void DamageSkill(EntityData attacker, EntityData defener)
    {
        Debug.Log("���b�p��ˮ`...");
        float recoveryAmount = CalculatorCritical(attacker) * currentDamage; // ��_�ޯ�[��
        float damage = Math.Max(attacker.currentDamage * 100 / (defener.currentDefense + 100), 1); // MOBA��k
        defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
        attacker.inBattle = true;
        defener.inBattle = true;
        if (attacker.iscritical)
        {
            Debug.Log(attacker.gameObject.name + " �����z��! �����O:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " �Ѿl��q: " + defener.currentHealth.ToString("f0"));
            return;
        }
        Debug.Log(attacker.gameObject.name + " �����O:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " �Ѿl��q: " + defener.currentHealth.ToString("f0"));
    }

    public void HealSkill(EntityData Healer, EntityData Healed)
    {
        Debug.Log("���b�v��...");
        float recoveryAmount = CalculatorCritical(Healer) * currentDamage; // ��_�ޯ�[��
        Healed.currentHealth = Math.Min(Healed.currentHealth + recoveryAmount, Healed.currentMaxHealth);
        Debug.Log(Healer.gameObject.name + " �� " + Healed.gameObject.name + " �^�_�F " + recoveryAmount.ToString("f0") + "\n�Ѿl��q: " + Healed.currentHealth.ToString("f0"));
    }

    float CalculatorCritical(EntityData attacker)
    {
        Debug.Log("���b�p��O�_�z��...");
        float random = UnityEngine.Random.value;
        attacker.iscritical = random <= attacker.criticalChance; // �üƤp���z���v=�z��
        float currentDamage = attacker.iscritical ? attacker.currentDamage * 2 : attacker.currentDamage;
        return currentDamage;
    }

    public float CalculateRandomDamage(EntityData attacker, float variable)
    {
        Debug.Log("���b�p���H���ˮ`...");
        float random = 0.3f; // �H���ˮ`�d��
        float currentDamage = attacker.currentDamage * variable;
        currentDamage = UnityEngine.Random.Range(currentDamage - currentDamage * random, currentDamage + currentDamage * random);
        return currentDamage;
    }

    public void UpdateOutOfCombatTime()
    {
        Debug.Log("���b��s�԰����A���ɶ�...");
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
