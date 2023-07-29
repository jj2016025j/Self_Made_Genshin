using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Organism : MonoBehaviour
{
    //public PlayerData copyPlayerData;
    //public PlayerData playerData;
    public PlayerUIManager playerUIManager;
    public SkillManager skillManager;
    public GameManager gameManager;

    /*public string objcetName
    {
        get { if (playerData != null) return playerData.objcetName; else return " "; }
        set { playerData.objcetName = value; }
    }

    public PlayerData.ObjectType objectType
    {
        get { if (playerData != null) return playerData.objectType; else return new PlayerData.ObjectType(); }
    }
    public PlayerData.ObjectState objectState
    {
        get { if (playerData != null) return playerData.objectState; else return new PlayerData.ObjectState(); }
        set { playerData.objectState = value; }
    }
    public void objectStateSwitch()
    {
        switch (objectState)
        {
            case PlayerData.ObjectState.Guard:
                //objectStateText.text = "�ݩR";
                break;
            case PlayerData.ObjectState.Patrol:
                //objectStateText.text = "Patrol";
                break;
            case PlayerData.ObjectState.Dead:
                //objectStateText.text = "���`";
                currentDeadTime = 0;
                break;
        }
        //objectStateText.text = "���A:" + objectStateText.text;
    }

    //��q
    public float maxHealth
    {
        get { if (playerData != null) return playerData.maxHealth; else return 0; }
        set { playerData.maxHealth = value; }
    }
    public float currentMaxHealth
    {
        get { if (playerData != null) return playerData.currentMaxHealth; else return 0; }
        set { playerData.currentMaxHealth = value; }
    }
    public float currentHealth
    {
        get { if (playerData != null) return playerData.currentHealth; else return 0; }
        set { playerData.currentHealth = value; }
    }
    
    //�^�_
    public float baseHealthRestore
    {
        get { if (playerData != null) return playerData.baseHealthRestore; else return 0; }
        set { playerData.baseHealthRestore = value; }
    }
    public float currentHealthRestore
    {
        get { if (playerData != null) return playerData.currentHealthRestore; else return 0; }
        set { playerData.currentHealthRestore = value; }
    }
    
    //���m
    public float currentDefense
    {
        get { if (playerData != null) return playerData.currentDefense; else return 0; }
        set { playerData.currentDefense = value; }
    }
    public float baseDefense
    {
        get { if (playerData != null) return playerData.baseDefense; else return 0; }
        set { playerData.baseDefense = value; }
    }
    
    //���`�ɶ�
    public float deadTime
    {
        get { if (playerData != null) return playerData.deadTime; else return 0; }
        set { playerData.deadTime = value; }
    }
    public float currentDeadTime
    {
        get { if (playerData != null) return playerData.currentDeadTime; else return 0; }
        set { playerData.currentDeadTime = value; }
    }
    
    //����
    public float baseDamage
    {
        get { if (playerData != null) return playerData.baseDamage; else return 0; }
        set { playerData.baseDamage = value; }
    }
    public float currentDamage
    {
        get { if (playerData != null) return playerData.currentDamage; else return 0; }
        set { playerData.currentDamage = value; }
    }
    public float criticalMultiplier
    {
        get { if (playerData != null) return playerData.criticalMultiplier; else return 0; }
        set { playerData.criticalMultiplier = value; }
    }//�z���[��
    public float criticalChance
    {
        get { if (playerData != null) return playerData.criticalChance; else return 0; }
        set { playerData.criticalChance = value; }
    }//�z�����v
    
    //��L
    public float attackRange
    {
        get { if (playerData != null) return playerData.attackRange; else return 0; }
        set { playerData.attackRange = value; }
    }
    public float skillRange
    {
        get { if (playerData != null) return playerData.skillRange; else return 0; }
        set { playerData.skillRange = value; }
    }
    public float coolDown
    {
        get { if (playerData != null) return playerData.coolDown; else return 0; }
        set { playerData.coolDown = value; }
    }

    //�԰�
    public bool inBattle
    {
        get { if (playerData != null) return playerData.inBattle; else return false; }
        set { playerData.inBattle = value; }
    }
    public float OutOfCombatTime
    {
        get { if (playerData != null) return playerData.OutOfCombatTime; else return 0; }
        set { playerData.OutOfCombatTime = value; }
    }
    
    //�t��
    public float baseSpeed
    {
        get { if (playerData != null) return playerData.baseSpeed; else return 0; }
        set { playerData.baseSpeed = value; }
    }
    public float currentSpeed
    {
        get { if (playerData != null) return playerData.currentSpeed; else return 0; }
        set { playerData.currentSpeed = value; }
    }
    
    //��L
    public int money
    {
        get { if (playerData != null) return playerData.money; else return 0; }
        set { playerData.money = value; }
    }

    //�����d��
    public float patrolRange
    {
        get { if (playerData != null) return playerData.patrolRange; else return 0; }
        set { playerData.patrolRange = value; }
    }
    public float sightRange
    {
        get { if (playerData != null) return playerData.sightRange; else return 0; }
        set { playerData.sightRange = value; }
    }
    */

    public enum ObjectType { Player, Monster, Material, AI };
    public enum ObjectState { Guard, Patrol, Chase, Dead, Attack };
    public ObjectType objectType;
    public ObjectState objectState;

    [Header("Stats Info")]
    //��q
    public float maxHealth;
    public float currentMaxHealth;
    public float currentHealth;
    //�^�_
    public float baseHealthRestore;
    public float currentHealthRestore;
    //���m
    public float baseDefense;
    public float currentDefense;
    //���`�ɶ�
    public float deadTime;
    public float currentDeadTime;

    [Header("Damage Info")]
    //����
    public float baseDamage;
    public float currentDamage;
    //��L
    public float attackRange;
    public float skillRange;
    public float coolDown;
    public float criticalMultiplier;//�z���[��
    public float criticalChance;//�z�����v
    public bool iscritical;

    [Header("Other Info")]
    //�԰�
    public bool inBattle;
    public float OutOfCombatTime;

    //�t��
    public float baseSpeed;
    public float currentSpeed;

    //��L
    public float luck;
    public int money;
    //public   bagData bagData;
    public float variable;

    [Header("AI Info")]
    //�����d��
    public float patrolRange;
    public float sightRange;


    public virtual void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerUIManager = GetComponent<PlayerUIManager>();
        skillManager = GetComponent<SkillManager>();
        UpdateInformation();
    }

    public void Update()
    {
        HealthRestore();
        UpdateOutOfCombatTime();
        MakeSureHealth();
        UpdateDeadTime();
    }

    public virtual void HealthRestore()
    {
        if (objectState != ObjectState.Dead)//�T�O���`���ɦ� //���|�Q����
        {
            HealthRestore(currentHealth, currentMaxHealth, currentHealthRestore);
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

    public void MakeSureHealth()
    {
        MakeSureHealth(currentHealth, maxHealth, objectState, objectType, currentDeadTime);
    }

    public void UpdatePlayer()
    {
        UpdateCharacter();
    }

    //Active
    public void Attack()
    {

    }

    public void Restore()
    {

    }

    public void AttackAll()
    {

    }

    public void RestoreAll()
    {

    }

    public void Jump()
    {

    }

    public void Move()
    {

    }
    public void UpdateInformation()
    {
        currentHealth = maxHealth;
        currentMaxHealth = maxHealth;
        currentHealthRestore = baseHealthRestore;
        currentDefense = baseDefense;
        currentDamage = baseDamage;
        currentSpeed = baseSpeed;
    }


    public void objectStateSwitch(ObjectState objectState, float currentDeadTime)
    {
        switch (objectState)
        {
            case ObjectState.Guard:
                //objectStateText.text = "�ݩR";
                break;
            case ObjectState.Patrol:
                //objectStateText.text = "Patrol";
                break;
            case ObjectState.Dead:
                //objectStateText.text = "���`";
                currentDeadTime = 0;
                break;
        }
        //objectStateText.text = "���A:" + objectStateText.text;
    }
    //public Text objectStateText;

    public void UpdateDeadTime()//�p�⦺�`�ɶ�
    {
        if (objectState == ObjectState.Dead)
        {
            currentDeadTime += Time.deltaTime;
            //currentDeadTimeText.text = currentDeadTime.ToString("f0") + "/" + deadTime.ToString("f0");
            if (currentDeadTime >= deadTime)
            {
                objectState = ObjectState.Guard;
                //acimator.SetBool("Dead", false);
                //acimator.SetBool("Life", true);
                currentHealth = maxHealth;
                currentDeadTime = 0;
                UpdateCharacter();
            }
        }
    }

    public void UpdateCharacter()//��s��T
    {
        switch (objectType)
        {
            case ObjectType.Player:
                //objectTypeText.text = "Player";
                //currentHealthRestoreText.text = "�^�_:" + (100 * currentHealthRestore).ToString("f0") + "%";

                //criticalchanceText.text = "�z�����v:" + (100 * criticalchance).ToString("f0") + "%";
                //currentDamageText.text = "�����O:" + currentDamage.ToString("f0");

                break;
            case ObjectType.Monster:
                //objectTypeText.text = "Monster";
                //currentDamageText.text = "�����O:" + currentDamage.ToString("f0");

                break;
            case ObjectType.Material:
                //objectTypeText.text = "Material";
                break;
        }
        objectStateSwitch(objectState, currentDeadTime);
        //objectTypeText.text = "����:" + objectTypeText.text;
        //objcetNameText.text = "�W��:" + objcetName;
        //currentHealthText.text = "��q" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
        //currentDefenceText.text = "���m:" + currentDefense.ToString("f0");
        //Convert.ToString(currentHealthRestore)�p�ƥγo��
        //criticalchance.ToString("f0.00")��ƥγo��
        //currentDeadTimeText.text = (objectState == ObjectState.Dead) ? currentDeadTime + "/" + deadTime : " ";
    }

    public void HealthRestore(float currentHealth, float currentMaxHealth, float currentHealthRestore)//��q�^�_
    {
        currentHealth = currentHealth + currentMaxHealth * currentHealthRestore * Time.deltaTime;
        //currentHealthText.text = "��q" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");

    }

    public void MakeSureHealth(float currentHealth, float maxHealth, ObjectState objectState, ObjectType objectType, float currentDeadTime)//�T�{��q���A
    {
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth <= 0.5f && (objectState != ObjectState.Dead))
        {
            currentHealth = 0;
            objectState = ObjectState.Dead;
            //acimator.SetBool("Dead", true);
            //acimator.SetBool("Life", false);
            UpdateCharacter();
        }
        else if (currentHealth <= 0.5f)
        {
            currentHealth = 0;
        }
        //currentHealthText.text = "��q" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
        if (objectState == ObjectState.Dead && currentHealth > 0)
        {
            currentHealth = 0;
        }
    }

    public void TakeDamage(Organism attacker, Organism defener)//��X�����̪������O��h�Q�����̪����m�᪺�ˮ`
    {
        float ��_�q = CalculatorCritical(attacker) * variable;// ��_�ޯ�[��

        float damage = Math.Max(attacker.currentDamage * 100 / (defener.currentDefense + 100), 1);//MOBA��k
        defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
        UpdateCharacter();
        attacker.inBattle = true;
        defener.inBattle = true;
        //defener.acimator.SetTrigger("Hit");
        if (attacker.iscritical)
        {
            Debug.Log("�z��" + "�����O:" + damage.ToString("f0") + "�Ѿl��q: " + defener.currentHealth.ToString("f0"));
            return;
            //defener.GetComponent<Animator>().SetTrigger("Hit");
        }

        Debug.Log("�����O:" + damage.ToString("f0") + "�Ѿl��q: " + defener.currentHealth.ToString("f0"));
    }

    public void Heal(Organism Healer, Organism Healed, float variable, ObjectType objectType, ObjectState objectState, float currentDeadTime)
    {
        float recoveryAmount = CalculatorCritical(Healer) * variable;// ��_�ޯ�[��
        Healed.currentHealth = Math.Min(Healed.currentHealth + recoveryAmount, Healed.currentMaxHealth);
        UpdateCharacter();
        Debug.Log("�^�_�q:" + recoveryAmount.ToString("f0") + "�Ѿl��q: " + Healed.currentHealth.ToString("f0"));
    }

    float CalculatorCritical(Organism attacker)
    {
        float random = UnityEngine.Random.value;
        attacker.iscritical = random <= attacker.criticalChance;//�üƤp���z���v=�z��
        float currentDamage = attacker.iscritical ? attacker.currentDamage * 2 : attacker.currentDamage;
        return currentDamage;
    }

    public float CurrentValue(Organism attacker, float variable)//�p���H���ˮ`
    {
        float random = 0.3f;//�H���ˮ`�d��
        float currentDamage = attacker.currentDamage * variable;
        currentDamage = UnityEngine.Random.Range(currentDamage - currentDamage * random, currentDamage + currentDamage * random);

        return currentDamage;
    }

    void Start()
    {

    }

}
