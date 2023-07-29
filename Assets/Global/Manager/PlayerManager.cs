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
    }

}