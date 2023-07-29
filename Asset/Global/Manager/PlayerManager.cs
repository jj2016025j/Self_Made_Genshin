using UnityEngine;

public partial class PlayerManager : Organism
{   
    public PlayerManager() { }

    public PlayerUIManager PlayerUIManager;
    
    public override void Start()
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
        //UNDO ��ܴ_���a�I ��a�_���Φ^�w���� �άO���s�C��
        //����Ҧ��ʧ@
        Debug.Log("���a���`");

    }
}