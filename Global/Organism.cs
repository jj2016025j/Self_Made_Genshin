using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism : MonoBehaviour
{
    public GameManager GameManager;
    public SkillManager SkillManager;
    public PlayerUIManager PlayerUIManager;

    public enum ObjectType { Player, Monster, Material, AI };
    public enum ObjectState { Guard, Patrol, Chase, Dead, Attack };
    public ObjectType objectType;
    public ObjectState objectState;

    [Header("Stats Info")]
    //血量
    public float maxHealth;
    public float currentMaxHealth;
    public float currentHealth;
    //回復
    public float baseHealthRestore;
    public float currentHealthRestore;
    //防禦
    public float baseDefense;
    public float currentDefense;
    //死亡時間
    public float deadTime;
    public float currentDeadTime;

    [Header("Damage Info")]
    //攻擊
    public float baseDamage;
    public float currentDamage;
    //其他
    public float attackRange;
    public float skillRange;
    public float coolDown;
    public float criticalMultiplier;//爆擊加成
    public float criticalChance;//爆擊機率
    public bool iscritical;

    [Header("Other Info")]
    //戰鬥
    public bool inBattle;
    public float OutOfCombatTime;

    //速度
    public float baseSpeed;
    public float currentSpeed;

    //其他
    public float luck;
    public int money;
    //public   bagData bagData;
    public float variable;

    [Header("AI Info")]
    //偵測範圍
    public float patrolRange;
    public float sightRange;


    public virtual void Awake()
    {
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
        if (objectState != ObjectState.Dead)//確保死亡不補血 //不會被攻擊
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
                //objectStateText.text = "待命";
                break;
            case ObjectState.Patrol:
                //objectStateText.text = "Patrol";
                break;
            case ObjectState.Dead:
                //objectStateText.text = "死亡";
                currentDeadTime = 0;
                break;
        }
        //objectStateText.text = "狀態:" + objectStateText.text;
    }
    //public Text objectStateText;

    public void UpdateDeadTime()//計算死亡時間
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

    public void UpdateCharacter()//更新資訊
    {
        switch (objectType)
        {
            case ObjectType.Player:
                //objectTypeText.text = "Player";
                //currentHealthRestoreText.text = "回復:" + (100 * currentHealthRestore).ToString("f0") + "%";

                //criticalchanceText.text = "爆擊機率:" + (100 * criticalchance).ToString("f0") + "%";
                //currentDamageText.text = "攻擊力:" + currentDamage.ToString("f0");

                break;
            case ObjectType.Monster:
                //objectTypeText.text = "Monster";
                //currentDamageText.text = "攻擊力:" + currentDamage.ToString("f0");

                break;
            case ObjectType.Material:
                //objectTypeText.text = "Material";
                break;
        }
        objectStateSwitch(objectState, currentDeadTime);
        //objectTypeText.text = "種類:" + objectTypeText.text;
        //objcetNameText.text = "名稱:" + objcetName;
        //currentHealthText.text = "血量" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
        //currentDefenceText.text = "防禦:" + currentDefense.ToString("f0");
        //Convert.ToString(currentHealthRestore)小數用這個
        //criticalchance.ToString("f0.00")整數用這個
        //currentDeadTimeText.text = (objectState == ObjectState.Dead) ? currentDeadTime + "/" + deadTime : " ";
    }

    public void HealthRestore(float currentHealth, float currentMaxHealth, float currentHealthRestore)//血量回復
    {
        currentHealth = currentHealth + currentMaxHealth * currentHealthRestore * Time.deltaTime;
        //currentHealthText.text = "血量" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");

    }

    public void MakeSureHealth(float currentHealth, float maxHealth, ObjectState objectState, ObjectType objectType, float currentDeadTime)//確認血量狀態
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
        //currentHealthText.text = "血量" + currentHealth.ToString("f0") + "/" + currentMaxHealth.ToString("f0");
        if (objectState == ObjectState.Dead && currentHealth > 0)
        {
            currentHealth = 0;
        }
    }

    public void TakeDamage(Organism attacker, Organism defener)//算出攻擊者的攻擊力減去被攻擊者的防禦後的傷害
    {
        float 恢復量 = CalculatorCritical(attacker) * variable;// 恢復技能加成

        float damage = Math.Max(attacker.currentDamage * 100 / (defener.currentDefense + 100), 1);//MOBA算法
        defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
        UpdateCharacter();
        attacker.inBattle = true;
        defener.inBattle = true;
        //defener.acimator.SetTrigger("Hit");
        if (attacker.iscritical)
        {
            Debug.Log("爆擊" + "攻擊力:" + damage.ToString("f0") + "剩餘血量: " + defener.currentHealth.ToString("f0"));
            return;
            //defener.GetComponent<Animator>().SetTrigger("Hit");
        }

        Debug.Log("攻擊力:" + damage.ToString("f0") + "剩餘血量: " + defener.currentHealth.ToString("f0"));
    }

    public void Heal(Organism Healer, Organism Healed, float variable, ObjectType objectType, ObjectState objectState, float currentDeadTime)
    {
        float recoveryAmount = CalculatorCritical(Healer) * variable;// 恢復技能加成
        Healed.currentHealth = Math.Min(Healed.currentHealth + recoveryAmount, Healed.currentMaxHealth);
        UpdateCharacter();
        Debug.Log("回復量:" + recoveryAmount.ToString("f0") + "剩餘血量: " + Healed.currentHealth.ToString("f0"));
    }

    float CalculatorCritical(Organism attacker)
    {
        float random = UnityEngine.Random.value;
        attacker.iscritical = random <= attacker.criticalChance;//亂數小於爆擊率=爆擊
        float currentDamage = attacker.iscritical ? attacker.currentDamage * 2 : attacker.currentDamage;
        return currentDamage;
    }

    public float CurrentValue(Organism attacker, float variable)//計算隨機傷害
    {
        float random = 0.3f;//隨機傷害範圍
        float currentDamage = attacker.currentDamage * variable;
        currentDamage = UnityEngine.Random.Range(currentDamage - currentDamage * random, currentDamage + currentDamage * random);

        return currentDamage;
    }

    void Start()
    {

    }

}
