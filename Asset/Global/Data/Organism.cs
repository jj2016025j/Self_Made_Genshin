using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class Organism : MonoBehaviour
{
    public GameManager GameManager;

    public GameObject closeone;

    [Header("SKILL")]
    public ChaseSkill chaseSkill;
    public HelfChaseSkill helfChaseSkill;
    public LineSkill lineSkill;
    public DownSkill downSkill;
    public CloseSkill closeSkill;

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

    public virtual void Start()
    {

    }

    public virtual void Update()
    {
        //UNDO 死亡後防止扣寫 執行移動或技能

        if (objectState != ObjectState.Dead)
        {
            HealthRestore(currentHealth, currentMaxHealth, currentHealthRestore);//確保死亡不補血 //不會被攻擊  可回血
            UpdateOutOfCombatTime();//OK
            MakeSureHealth();//Combat Dead
            UpdateOutOfCombatTime();
        }
        else
        {
            currentHealth = 0;
            UpdateDeadTime();
        }
        UpdateUI();
    }


    //Active
    public void Jump()
    {

    }

    public void Move()
    {

    }

    public void AttackSelf()//測試用
    {
        TakeDamage(this, this);
    }

    public void Restore()
    {
        Heal(this, this);
    }

    public void HelfChaseSkill()//HelfChaseSkill
    {
        var closestMonster = FindClosestMonster(GameManager.MapManager.MonsterManagers);
        if (closestMonster == null)
        {
            return;
        }
        for (int i = 1; i < 5; i++)
        {
            closestMonster = FindClosestMonster(GameManager.MapManager.MonsterManagers);
            var randomDirection = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);
            var helfChaseObject = Instantiate(helfChaseSkill.gameObject, transform.position + new Vector3(0, 2.5f, 0), randomDirection);
            helfChaseObject.GetComponent<HelfChaseSkill>().selfOrganism = this;
            helfChaseObject.GetComponent<HelfChaseSkill>().targetOrganism = closestMonster.GetComponent<Organism>();
            Destroy(helfChaseObject, 5);
        }
    }

    public void ChaseSkill()//ChaseSkill
    {
        if (GameManager.MapManager.MonsterManagers == null)
        {
            return;
        }
        closeone = FindClosestMonster(GameManager.MapManager.MonsterManagers);
        GameObject gameObject = closeone != null ? Instantiate(chaseSkill.gameObject, transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity) : null;
        gameObject.GetComponent<ChaseSkill>().selfOrganism = this;
        gameObject.GetComponent<ChaseSkill>().targetOrganism = closeone.GetComponent<Organism>();
        Destroy(gameObject, 3);
    }

    public void LineSkill()//LineSkill
    {
        GameObject gameObject = Instantiate(lineSkill.gameObject, transform.position + new Vector3(0, 1.0f, 0) + transform.forward*1f, Quaternion.identity);//Vector3(0, 1, 0)可以瞬移
        gameObject.GetComponent<LineSkill>().selfOrganism = this;
        gameObject.GetComponent<LineSkill>().direction = transform.forward;

        Destroy(gameObject,2);
    }

    public Transform target;
    public int numberOfMeteors = 10;

    public void DownSkill()//DownSkill
    {
        if (GameManager.MapManager.MonsterManagers == null)
        {
            return;
        }
        closeone = FindClosestMonster(GameManager.MapManager.MonsterManagers);
        for (int i = 1; i < numberOfMeteors; i++)
        {
            Vector3 randomPosition = closeone.transform.position + new Vector3(Random.Range(-10, 10), 20, Random.Range(-10, 10));
            GameObject gameObject = closeone ? Instantiate(downSkill.gameObject, randomPosition, Quaternion.identity) : null;
            gameObject.GetComponent<DownSkill>().selfOrganism = this;
            gameObject.GetComponent<DownSkill>().targetOrganism = closeone.GetComponent<Organism>();
            gameObject.GetComponent<DownSkill>().target = gameObject.GetComponent<DownSkill>().targetOrganism.transform;
            Destroy(gameObject, 2);
            //Bug
            StartCoroutine(CoroutineTest());
        }
    }

    public void CloseSkill()//Close
    {
        //UNDO ChaseSkill
        GameObject gameObject = Instantiate(closeSkill.gameObject, transform.position + new Vector3(0, 1, 0) + transform.forward * 1.2f, transform.rotation);
        gameObject.GetComponent<CloseSkill>().selfOrganism = this;
    }


    //Update
    public void UpdateInformation()
    {
        currentHealth = maxHealth;
        currentMaxHealth = maxHealth;
        currentHealthRestore = baseHealthRestore;
        currentDefense = baseDefense;
        currentDamage = baseDamage;
        currentSpeed = baseSpeed;
    }

    public void HealthRestore(float _currentHealth, float currentMaxHealth, float currentHealthRestore)//血量回復
    {
        currentHealth = _currentHealth + currentMaxHealth * currentHealthRestore / 100 * Time.deltaTime;
    }

    public void MakeSureHealth()
    {
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth <= 0.5f)
        {
            currentHealth = 0;
            objectState = ObjectState.Dead;
            IfDead();
            currentDeadTime = deadTime;
            OutOfCombatTime = 10;
        }
    }

    public void UpdateDeadTime()//計算死亡時間
    {
        currentDeadTime -= Time.deltaTime;
        if (currentDeadTime <= 0)
        {
            objectState = ObjectState.Guard;
            currentHealth = maxHealth;
            currentDeadTime = deadTime;
            UpdateCharacter();
        }
    }

    public virtual void IfDead()
    {

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

    //???
    public void UpdateCharacter()//更新資訊
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
                currentDeadTime = deadTime;
                break;
        }
        UpdateUI();
    }

    //Calculate
    public void TakeDamage(Organism attacker, Organism defener)//算出攻擊者的攻擊力減去被攻擊者的防禦後的傷害
    {
        float 恢復量 = CalculatorCritical(attacker) * variable;// 恢復技能加成

        float damage = Math.Max(attacker.currentDamage * 100 / (defener.currentDefense + 100), 1);//MOBA算法
        defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
        attacker.inBattle = true;
        defener.inBattle = true;
        //defener.acimator.SetTrigger("Hit");
        UpdateCharacter();
        if (attacker.iscritical)
        {
            Debug.Log(attacker.gameObject.name + " 產生爆擊! 攻擊力:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " 剩餘血量: " + defener.currentHealth.ToString("f0"));
            return;
            //defener.GetComponent<Animator>().SetTrigger("Hit");
        }
        Debug.Log(attacker.gameObject.name + " 攻擊力:" + damage.ToString("f0") + "\n" + defener.gameObject.name + " 剩餘血量: " + defener.currentHealth.ToString("f0"));
    }

    public void Heal(Organism Healer, Organism Healed)
    {
        float recoveryAmount = CalculatorCritical(Healer) * variable;// 恢復技能加成
        Healed.currentHealth = Math.Min(Healed.currentHealth + recoveryAmount, Healed.currentMaxHealth);
        UpdateCharacter();
        Debug.Log(Healer.gameObject.name + " 對 " + Healed.gameObject.name + " 回復了 " + recoveryAmount.ToString("f0") + "\n剩餘血量: " + Healed.currentHealth.ToString("f0"));
    }

    float CalculatorCritical(Organism attacker)
    {
        float random = UnityEngine.Random.value;
        attacker.iscritical = random <= attacker.criticalChance;//亂數小於爆擊率=爆擊
        float currentDamage = attacker.iscritical ? attacker.currentDamage * 2 : attacker.currentDamage;
        return currentDamage;
    }

    public float CurrentValue(Organism attacker, float variable)//CalculateRandomDamage
    {
        float random = 0.3f;//隨機傷害範圍
        float currentDamage = attacker.currentDamage * variable;
        currentDamage = UnityEngine.Random.Range(currentDamage - currentDamage * random, currentDamage + currentDamage * random);

        return currentDamage;
    }

    public virtual void UpdateUI()
    {

    }

    public GameObject FindClosestMonster(List<GameObject> monsterManagers)//UNDO 沒怪的時候
    {
        if (monsterManagers == null || monsterManagers.Count == 0)
        {
            return null;
        }
        GameObject closestMonster = monsterManagers[0];
        float closestDistance = Vector3.Distance(transform.position, monsterManagers[0].transform.position);

        foreach (var monster in monsterManagers)
        {
            float currentDistance = Vector3.Distance(transform.position, monster.transform.position);
            if (currentDistance < closestDistance)
            {
                closestMonster = monster;
                closestDistance = currentDistance;
            }
        }
        return closestMonster;
    }
    IEnumerator CoroutineTest()
    {
        Debug.Log("CoroutineTest Start At" + Time.time);
        yield return new WaitForSeconds(1000.0f);
        Debug.Log("CoroutineTest End At" + Time.time);
    }
}
