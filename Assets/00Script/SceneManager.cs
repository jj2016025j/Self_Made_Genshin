using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SceneManager : Singleton<SceneManager>
{    
    public GameObject characterPrefab;  // 角色的預置物
    public Transform spawnPoint;        // 角色生成點的位置

    public GameObject Slime;  // 怪物的預設模板
    public List<GameObject> Monsters;  // 怪物列表

    public MonsterManager MonsterManager;  // 怪物管理

    public int StartUnitQuantity = 5;  // 開始時的怪物數量
    public int UnitQuantityUpperLimit = 20;  // 最大的怪物數量

    public float InstantiateTimeWhenStart = 0;  // 每隔多少時間生成怪物
    public float InstantiateTime = 10;  // 每隔多少時間生成怪物
    
    public float InstantiateRange = 100;  // 怪物生成範圍

    // 在遊戲開始時調用
    public override void Awake()
    {
        base.Awake();
        // 載入預置體
        /*characterPrefab = characterPrefab != null ? characterPrefab : Resources.Load<GameObject>("00Script/test");
        Slime = Slime != null ? Slime : Resources.Load<GameObject>("00Script/test");
        */
        // 如果 spawnPoint 為 null，則將其設置為 transform
        spawnPoint = spawnPoint != null ? spawnPoint : transform;

        // 確保載入了這些預置體
        /*Debug.Assert(characterPrefab != null, "未能載入 characterPrefab 預置體");
        Debug.Assert(Slime != null, "未能載入 Slime 預置體");*/
        Debug.Assert(spawnPoint != null, "未找到 spawnPoint 物體");

        StartCoroutine(InitSpawn());  // 開始協同程序，生成初始的怪物
        Debug.Log("遊戲開始，初始化【怪物生成】");  // 在控制台輸出提示訊息
        SpawnCharacter();  // 透過 GameManager 的實例來呼叫 SpawnCharacter() 方法
    }

    //生成玩家角色
    public void SpawnCharacter()
    {
        try
        {
            // 可能會拋出異常的程式碼
            Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        catch (InvalidCastException e)
        {
            // 處理 InvalidCastException 的程式碼
            Debug.Log("Caught an InvalidCastException: " + e.Message);
        }
        Debug.Log("生成角色");

        // 在這裡可以對生成的角色進行進一步的設定和初始化
    }

    // 生成怪物的方法
    private void SpawnMonster()
    {
        // 如果達到怪物數量上限或者模板不存在，則不生成怪物
        if (Monsters.Count >= UnitQuantityUpperLimit)
        {
            return;
        }
        GameObject monster = Slime;
        // 生成怪物
        try
        {
            // 可能會拋出異常的程式碼
            monster = Instantiate(Slime, new Vector3(Random.Range(-InstantiateRange, InstantiateRange), spawnPoint.position.y, Random.Range(-InstantiateRange, InstantiateRange)), Quaternion.identity);
        }
        catch (InvalidCastException e)
        {
            // 處理 InvalidCastException 的程式碼
            Debug.LogError("Caught an InvalidCastException: " + e.Message);
        }

        Monsters.Add(monster);
        Debug.Log("【生成】一隻怪物，當前怪物數量: " + Monsters.Count);
    }

    public void CleanAllMonster()
    {
        // 首先確保 Monsters 列表不為 null
        if (Monsters != null)
        {
            // 從最後一個怪物開始刪除，直到清空怪物列表
            for (int i = Monsters.Count - 1; i >= 0; i--)
            {
                // 檢查怪物物件是否為 null
                if (Monsters[i] != null)
                {
                    // 請求怪物死亡
                    Monsters[i].GetComponent<Monster>().Die();
                }

                // 在控制台輸出刪除怪物的訊息
                Debug.Log("請求第" + (i + 1) + "隻怪物【死亡】");
            }

            // 在控制台輸出已清空所有怪物的訊息
            Debug.Log("已請求【所有】怪物【死亡】");
        }
        else
        {
            // 在控制台輸出 Monsters 列表為 null 的訊息
            Debug.Log("Monsters 列表為 null");
        }
    }

    // 從怪物列表中移除指定的怪物
    public void RemoveMonster(GameObject monster)
    {
        if (Monsters.Contains(monster))
        {
            // 從怪物列表中移除此怪物
            Monsters.Remove(monster);

            // 在控制台輸出移除怪物的訊息
            Debug.Log("從怪物列表中移除 " + monster.name);
        }
    }

    // 協同程序，用於初始化生成怪物
    IEnumerator InitSpawn()
    {
        // 初始化生成怪物
        for (int i = 0; i < StartUnitQuantity; i++)
        {
            Debug.Log("初始化生成怪物");
            SpawnMonster();
            yield return new WaitForSeconds(InstantiateTimeWhenStart);  // 等待一定的時間
        }

        // 開始定期生成怪物
        StartCoroutine(SpawnLoop());
    }

    // 協同程序，用於定期生成怪物
    IEnumerator SpawnLoop()
    {
        while (true)
        {
            Debug.Log("定期生成怪物");
            SpawnMonster();
            yield return new WaitForSeconds(InstantiateTime);  // 等待一定的時間
        }
    }
}
