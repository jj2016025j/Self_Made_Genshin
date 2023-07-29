using UnityEngine;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    public int health;  // 怪物的生命值
    public int attackPower;  // 怪物的攻擊力


    void Start()
    {
        SceneManager sceneManager = FindObjectOfType<SceneManager>();
        Debug.Log("怪物被創建，目前總數：" + sceneManager.Monsters);
    }

    void OnDestroy()
    {
        SceneManager sceneManager = FindObjectOfType<SceneManager>();
        Debug.Log("怪物被銷毀，目前總數：" + sceneManager.Monsters);
    }


    // 怪物更新
    void Update()
    {
        // 更新怪物的行為或狀態
    }

    /*public override void Initialize()
    {
        base.Initialize();
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

        //攻擊
        baseDamage = 10;
        currentDamage = 10;
        //其他
        attackRange = 10;
        criticalMultiplier = 50;//爆擊加成
        criticalChance = 10;//爆擊機率
        variable = 1;//Balance
        name = "NO." + Random.Range(0, 100).ToString() + " Slime";
    }*/

    // 怪物受到攻擊
    public void TakeDamage(int damage)
    {
        // 處理怪物受到攻擊時的行為
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // 怪物攻擊
    public void Attack()
    {
        // 處理怪物進行攻擊時的行為
    }

    // 怪物死亡
    private void Die()
    {
        // 處理怪物死亡時的行為
        Destroy(gameObject);
    }
}
