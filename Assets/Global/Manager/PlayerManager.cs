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
                //objectStateText.text = "待命";
                break;
            case PlayerData.ObjectState.Patrol:
                //objectStateText.text = "Patrol";
                break;
            case PlayerData.ObjectState.Dead:
                //objectStateText.text = "死亡";
                currentDeadTime = 0;
                break;
        }
        //objectStateText.text = "狀態:" + objectStateText.text;
    }

    //血量
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
    
    //回復
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
    
    //防禦
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
    
    //死亡時間
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
    
    //攻擊
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
    }//爆擊加成
    public float criticalChance
    {
        get { if (playerData != null) return playerData.criticalChance; else return 0; }
        set { playerData.criticalChance = value; }
    }//爆擊機率
    
    //其他
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

    //戰鬥
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
    
    //速度
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
    
    //其他
    public int money
    {
        get { if (playerData != null) return playerData.money; else return 0; }
        set { playerData.money = value; }
    }

    //偵測範圍
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
        //血量
        maxHealth = 100;
        currentMaxHealth = 100;
        currentHealth = 100;
        //回復
        baseHealthRestore = 1;
        currentHealthRestore = 1;
        //防禦
        baseDefense = 10;
        currentDefense = 10;
        deadTime = 15;
        currentDeadTime = 0;

        //攻擊
        baseDamage = 10;
        currentDamage = 10;
        //其他
        attackRange = 10;
        criticalMultiplier = 50;//爆擊加成
        criticalChance = 10;//爆擊機率

}
public void TakeDamageSelf(PlayerManager attacker)//測試用
    {
        TakeDamage(attacker, attacker);
        UpdateCharacter();
    }

}