using UnityEngine;

public partial class PlayerManager : Organism
{   
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
    }

}