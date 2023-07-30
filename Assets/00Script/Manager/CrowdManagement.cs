using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrowdManagement : MonoBehaviour
{
    public GameObject slimePrefab;  // 怪物的預設模板
    public List<GameObject> monsters;  // 怪物列表

    public int startUnitQuantity = 10;  // 開始時的怪物數量
    public int unitQuantityUpperLimit = 20;  // 最大的怪物數量

    public float instantiateTimeWhenStart = 0;  // 開始生成怪物的間隔時間
    public float instantiateTime = 1;  // 生成怪物的間隔時間

    public float instantiateRange = 50;  // 怪物生成範圍

    void Start()
    {
        Debug.Log("怪物管理器初始化，開始【怪物生成】");
        StartCoroutine(InitSpawn());  // 開始協同程序，生成初始的怪物
    }

    // 生成怪物的方法
    private void SpawnMonster()
    {
        if (monsters.Count >= unitQuantityUpperLimit)
        {
            return; // 達到怪物上限，停止生成
        }
        GameObject monster = slimePrefab;

        try
        {
            // 生成怪物的隨機位置
            Vector3 spawnPosition = new Vector3(Random.Range(-instantiateRange, instantiateRange), transform.position.y, Random.Range(-instantiateRange, instantiateRange));

            // 隨機旋轉角度（只在 Y 軸上旋轉）
            Quaternion spawnRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            // 生成怪物
            monster = Instantiate(slimePrefab, spawnPosition, spawnRotation);
        }
        catch (InvalidCastException e)
        {
            Debug.LogError("Caught an InvalidCastException: " + e.Message);
        }

        monsters.Add(monster);
        Debug.Log("【生成】一隻怪物，當前怪物數量: " + monsters.Count);
    }

    // 協同程序，用於初始化生成怪物
    IEnumerator InitSpawn()
    {
        for (int i = 0; i < startUnitQuantity; i++)
        {
            Debug.Log("初始化生成怪物");
            SpawnMonster();
            yield return new WaitForSeconds(instantiateTimeWhenStart);  // 開始生成怪物的間隔時間
        }

        StartCoroutine(SpawnLoop()); // 開始定期生成怪物
    }

    // 協同程序，用於定期生成怪物
    IEnumerator SpawnLoop()
    {
        while (true)
        {
            Debug.Log("定期生成怪物");
            SpawnMonster();
            yield return new WaitForSeconds(instantiateTime);  // 生成怪物的間隔時間
        }
    }

    //刪除怪物列表中所有怪物
    public void CleanAllMonster()
    {
        // 首先確保 Monsters 列表不為 null
        if (monsters != null)
        {
            // 從最後一個怪物開始刪除，直到清空怪物列表
            for (int i = monsters.Count - 1; i >= 0; i--)
            {
                // 檢查怪物物件是否為 null
                if (monsters[i] != null)
                {
                    // 請求怪物死亡
                    RemoveMonster(monsters[i]);
                }
            }
            // 在控制台輸出已清空所有怪物的訊息
            Debug.Log("已請求【所有】怪物【死亡】");
        }
        else
        {
            // 在控制台輸出 Monsters 列表為 null 的訊息
            Debug.Log("Monsters 列表為 null");
        }
        monsters.Clear();
    }

    // 從怪物列表中移除指定的怪物
    public void RemoveMonster(GameObject monster)
    {
        Destroy(monster);
        if (monsters.Contains(monster))
        {
            monsters.Remove(monster); // 從怪物列表中移除此怪物
            Debug.Log("從怪物列表中移除 " + monster.name);
        }
    }
    
    // 從怪物列表中移除指定的怪物
    public void RemoveRandomMonster()
    {
        Monstermanager monster = FindObjectOfType<Monstermanager>();
        if (monster != null)
        {
            RemoveMonster(monster.gameObject);
        }
        else
        {
            Debug.Log("沒有找到任何 Monster 物件");
        }
    }
}
