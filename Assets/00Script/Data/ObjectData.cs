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
    //��q
    public float maxHealth=100;
    public float currentMaxHealth = 100;
    public float currentHealth = 100;
    //�^�_%
    public float baseHealthRestore = 1;
    public float currentHealthRestore = 1;
    //���m
    public float baseDefense = 10;
    public float currentDefense = 10;

    [Header("Damage Info")]
    //����
    public float baseDamage = 10;
    public float currentDamage = 10;

    //�԰�
    public bool inBattle=false;
    public float OutOfCombatTime = 10;

    //��L
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
        //UNDO ���`�ᨾ��g ���沾�ʩΧޯ�

        if (objectState != ObjectState.Dead)
        {
            HealthRestore(currentHealth, currentMaxHealth, currentHealthRestore);//�T�O���`���ɦ� //���|�Q����  �i�^��
            MakeSureHealth();//Combat Dead
        }
    }
    //��l��
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

    public void HealthRestore(float _currentHealth, float currentMaxHealth, float currentHealthRestore)//��q�^�_
    {
        currentHealth = _currentHealth + currentMaxHealth * currentHealthRestore / 100 * Time.deltaTime;
    }

    //�קK���X  ���`��������A �I�s�}�⦺�`  �����԰����A
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

    //�ˮ`�ޯ�
    public void DamageSkill(OrganismData attacker, OrganismData defener)//��X�����̪������O��h�Q�����̪����m�᪺�ˮ`
    {
        float ��_�q = CalculatorCritical(attacker) * variable;// ��_�ޯ�[��

        float damage = Math.Max(attacker.currentDamage * 100 / (defener.currentDefense + 100), 1);//MOBA��k
        defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
        attacker.inBattle = true;
        defener.inBattle = true;
        //defener.acimator.SetTrigger("Hit");
        if (attacker.iscritical)
        {
            Debug.Log(attacker.gameObject.name + " �����z��! �����O:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " �Ѿl��q: " + defener.currentHealth.ToString("f0"));
            return;
            //defener.GetComponent<Animator>().SetTrigger("Hit");
        }
        Debug.Log(attacker.gameObject.name + " �����O:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " �Ѿl��q: " + defener.currentHealth.ToString("f0"));
    }

    //�v¡�ޯ�
    public void HealSkill(OrganismData Healer, OrganismData Healed)
    {
        float recoveryAmount = CalculatorCritical(Healer) * variable;// ��_�ޯ�[��
        Healed.currentHealth = Math.Min(Healed.currentHealth + recoveryAmount, Healed.currentMaxHealth);
        Debug.Log(Healer.gameObject.name + " �� " + Healed.gameObject.name + " �^�_�F " + recoveryAmount.ToString("f0") + "\n�Ѿl��q: " + Healed.currentHealth.ToString("f0"));
    }

    //�p������ˮ`
    float CalculatorCritical(OrganismData attacker)
    {
        float random = UnityEngine.Random.value;
        attacker.iscritical = random <= attacker.criticalChance;//�üƤp���z���v=�z��
        float currentDamage = attacker.iscritical ? attacker.currentDamage * 2 : attacker.currentDamage;
        return currentDamage;
    }

    //�p���H���ˮ`
    public float CalculateRandomDamage(OrganismData attacker, float variable)//CalculateRandomDamage
    {
        float random = 0.3f;//�H���ˮ`�d��
        float currentDamage = attacker.currentDamage * variable;
        currentDamage = UnityEngine.Random.Range(currentDamage - currentDamage * random, currentDamage + currentDamage * random);

        return currentDamage;
    }
}
