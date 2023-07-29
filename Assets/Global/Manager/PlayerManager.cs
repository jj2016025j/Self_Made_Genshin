using UnityEngine;

public partial class PlayerManager : Organism
{
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
    
    public PlayerManager() { }


    public override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
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

}
public void TakeDamageSelf(PlayerManager attacker)//���ե�
    {
        TakeDamage(attacker, attacker);
        UpdateCharacter();
    }

}