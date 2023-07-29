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
        //UNDO ���`�ᨾ��g ���沾�ʩΧޯ�

        if (objectState != ObjectState.Dead)
        {
            HealthRestore(currentHealth, currentMaxHealth, currentHealthRestore);//�T�O���`���ɦ� //���|�Q����  �i�^��
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

    public void UpdateCharacter()//��s��T
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
    public void TakeDamage(Organism attacker, Organism defener)//��X�����̪������O��h�Q�����̪����m�᪺�ˮ`
    {
        float ��_�q = CalculatorCritical(attacker) * variable;// ��_�ޯ�[��

        float damage = Math.Max(attacker.currentDamage * 100 / (defener.currentDefense + 100), 1);//MOBA��k
        defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
        attacker.inBattle = true;
        defener.inBattle = true;
        //defener.acimator.SetTrigger("Hit");
        UpdateCharacter();
        if (attacker.iscritical)
        {
            Debug.Log(attacker.gameObject.name + " �����z��! �����O:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " �Ѿl��q: " + defener.currentHealth.ToString("f0"));
            return;
            //defener.GetComponent<Animator>().SetTrigger("Hit");
        }
        Debug.Log(attacker.gameObject.name + " �����O:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " �Ѿl��q: " + defener.currentHealth.ToString("f0"));
    }

    public void Heal(Organism Healer, Organism Healed)
    {
        float recoveryAmount = CalculatorCritical(Healer) * variable;// ��_�ޯ�[��
        Healed.currentHealth = Math.Min(Healed.currentHealth + recoveryAmount, Healed.currentMaxHealth);
        UpdateCharacter();
        Debug.Log(Healer.gameObject.name + " �� " + Healed.gameObject.name + " �^�_�F " + recoveryAmount.ToString("f0") + "\n�Ѿl��q: " + Healed.currentHealth.ToString("f0"));
    }

    float CalculatorCritical(Organism attacker)
    {
        float random = UnityEngine.Random.value;
        attacker.iscritical = random <= attacker.criticalChance;//�üƤp���z���v=�z��
        float currentDamage = attacker.iscritical ? attacker.currentDamage * 2 : attacker.currentDamage;
        return currentDamage;
    }

    public float CurrentValue(Organism attacker, float variable)//CalculateRandomDamage
    {
        float random = 0.3f;//�H���ˮ`�d��
        float currentDamage = attacker.currentDamage * variable;
        currentDamage = UnityEngine.Random.Range(currentDamage - currentDamage * random, currentDamage + currentDamage * random);

        return currentDamage;
    }

    public virtual void UpdateUI()
    {

    }
}
