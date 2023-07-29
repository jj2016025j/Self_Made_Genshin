using UnityEngine;

public partial class PlayerManager : Organism
{   
    public PlayerManager() { }

    public PlayerUIManager PlayerUIManager;
    
    public override void Start()
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

        variable = 1;//Balance
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Z))
        {
            DownSkill();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            HelfChaseSkill();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            ChaseSkill();
        }
        if(Input.GetMouseButtonDown(0))
        {
            CloseSkill();
        }
        if (Input.GetMouseButtonDown(1))
        {
            LineSkill();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Restore();
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            AttackSelf();
        }
    }

    //Update
    public override void UpdateUI()
    {
        PlayerUIManager.UpdateUI(currentHealth, maxHealth);
    }

    public override void IfDead()
    {
        //UNDO 選擇復活地點 原地復活或回安全區 或是重新遊戲
        //停止所有動作
        Debug.Log("玩家死亡");

    }
}