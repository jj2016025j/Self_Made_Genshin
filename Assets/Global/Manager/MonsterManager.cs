using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : Organism
{
    //Target

    public MapManager MapManager;
    public PlayerManager PlayerManager;

    public GameObject UnitUI, UnitUIWorldSpace;
    public Image HealthBar, HealthBarWorldSpace;
    public TextMeshProUGUI UnitName, UnitNameWorldSpace;

    public override void Awake()
    {
        base.Awake();
        PlayerManager=GameObject.Find("GameManager").GetComponent<PlayerManager>();
    }

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
        name = "NO."+Random.Range(0, 100).ToString()+" Slime";

        GameManager = GameManager == null ? GameObject.Find("GameManager").GetComponent<GameManager>() : GameManager;
        MapManager = MapManager == null ? GameObject.Find("MapUI").GetComponent<MapManager>() : MapManager;
        PlayerManager = PlayerManager == null ? GameObject.Find("PlayerManager").GetComponent<PlayerManager>() : PlayerManager;
    }

    public override void Update()
    {
        base.Update();
        FindPlayer();
        // rotate health bar to face the camera/player
        UnitUIWorldSpace.transform.LookAt(Camera.main.transform.position);
    }

    //Update
    public override void UpdateUI()
    {
        UnitName.text = name;
        HealthBar.fillAmount = currentHealth / maxHealth;

        // update health bar value
        UnitNameWorldSpace.text = name;
        HealthBarWorldSpace.fillAmount = currentHealth / maxHealth;

        // hide health bar if needed
        UnitUIWorldSpace.SetActive(HealthBarWorldSpace.fillAmount != 1);
    }

    //偵測距離

    public override void IfDead()
    {
        if (this.gameObject != null)
        {
            MapManager.UnitDead(gameObject, UnitUI, UnitUIWorldSpace);
        }
    }
    void FindPlayer()
    {
        //偵測玩家是否在範圍內
    }

    //Active
    
}
