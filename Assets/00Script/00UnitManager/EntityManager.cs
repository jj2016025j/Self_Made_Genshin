using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//實體物件
public class EntityManager : MonoBehaviour
{
    //UI
    //material
    //attackable
    //register
    //mapPosition
    //do data
    //do input
    //do move

    public GameManager GameManager; // 遊戲管理器
    public EntityData objectData; // 物件的數據
    public SkillManager SkillManager; // 技能管理器 或是改成skill
    public CrowdManagement CrowdManager;  // 群體管理器

    public GameObject target; // 目標物件
    public GameObject damagePopupPrefab; // 傷害彈出的預製物件


    public void Awake()
    {
        // 從場景中找到場景管理器的實例
        CrowdManager = FindObjectOfType<CrowdManagement>();
    }

    // 在物件開始時初始化
    public virtual void Start()
    {
        Initialize();
        Debug.Log("怪物被【創建】，目前總數：" + CrowdManager.monsters.Count);

    }

    // 在每一幀更新UI
    public virtual void Update()
    {
        UpdateUI();
    }

    // 當怪物受到攻擊
    public void TakeDamage(int damage)
    {

    }

    // 死亡方法
    public void Dead()
    {
        DropLoot();
    }

    //怪物被銷毀
    void OnDestroy()
    {
        Debug.Log(gameObject.name + " 已經死亡");
        Debug.Log("怪物被【銷毀】，目前總數：" + (CrowdManager.monsters.Count));
    }

    // 掉落物品方法
    public void DropLoot()
    {
        foreach (LootData loot in objectData.lootTable)
        {
            int roll = Random.Range(0, 100);
            if (Random.value < loot.dropChance)
            {
                Instantiate(loot.item, transform.position, Quaternion.identity);
            }
        }
    }

    // 顯示傷害數值的方法
    public void DamagePopup(GameObject enemy, int damageAmount)
    {
        GameObject popupInstance = Instantiate(damagePopupPrefab, enemy.transform.position, Quaternion.identity);
        DamagePopup damagePopup = popupInstance.GetComponent<DamagePopup>();
        if (damagePopup != null)
        {
            damagePopup.Setup(damageAmount);
        }
    }

    // 初始化方法，可以在子類別中覆寫
    public virtual void Initialize()
    {

    }

    // 切換物件的狀態
    public void ObjectStateSwitch()
    {
        switch (objectData.objectState)
        {
            case ObjectState.Guard:
                break;
            case ObjectState.Patrol:
                break;
            case ObjectState.Dead:
                break;
        }
        UpdateUI();
    }


    // 更新UI的方法，可以在子類別中覆寫
    public virtual void UpdateUI()
    {

    }

}
