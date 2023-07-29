using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject Slime;  // 怪物的預設模板
    //public List<GameObject> Monsters;  // 管理所有生成的怪物
    public int Monsters;//怪物數量

    public int StartUnitQuantity = 5;  // 開始時的怪物數量
    public int UnitQuantityUpperLimit = 20;  // 最大的怪物數量

    public float InstantiateTime = 10;  // 每隔多少時間生成怪物
    private bool isSpawning = false;  // 是否應該生成怪物

    // 在遊戲開始時調用
    private void Awake()
    {
        StartCoroutine(InitSpawn());  // 開始協同程序，生成初始的怪物
        Debug.Log("遊戲開始，初始化怪物生成");  // 在控制台輸出提示訊息
        GameManager.Instance.SpawnCharacter();  // 透過 GameManager 的實例來呼叫 SpawnCharacter() 方法
    }

    // 協同程序，用於初始化生成怪物
    IEnumerator InitSpawn()
    {
        for (int i = 1; i <= StartUnitQuantity; i++)
        {
            InstantiateUnit();
            yield return new WaitForSeconds(1f);  // 等待一秒鐘
        }
        isSpawning = true;  //開始定期生成怪物
        StartCoroutine(SpawnLoop());  // 開始定期生成怪物的協同程序
    }

    // 協同程序，用於定期生成怪物
    IEnumerator SpawnLoop()
    {
        while (isSpawning)
        {
            InstantiateUnit();
            yield return new WaitForSeconds(InstantiateTime);  // 等待一定的時間
        }
    }

    // 生成怪物
    void InstantiateUnit()
    {
        if (/*Monsters.Count*/Monsters < UnitQuantityUpperLimit && Slime != null)  // 判斷是否達到怪物數量上限以及模板是否存在
        {
            var monster = GameObject.Instantiate(Slime, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
            //Monsters.Add(monster);
            Monsters += 1;
            Debug.Log("生成一隻怪物，當前怪物數量: " + Monsters/*Monsters.Count*/);
        }
        else if (Slime == null)
        {
            Debug.LogError("怪物模板未在Inspector中設定"); 
        }
    }

    // 清理所有怪物
    public void Clean()
    {
        for (int i = Monsters/*Monsters.Count*/ - 1; i >= 0; i--)
        {
            //Destroy(Monsters[i]);
            Monsters -= 1;
        }
        //Monsters.Clear();
        Monsters = 0;
        Debug.Log("清空所有怪物");
    }
}
