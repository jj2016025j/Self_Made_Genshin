using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject monsterPrefab;        // 怪物的預置物
    public Transform[] spawnPoints;         // 怪物生成點的位置
    public int maxMonsterCount = 10;        // 最大怪物數量
    public float checkInterval = 1f;        // 檢查怪物數量的間隔時間

    private int currentMonsterCount = 0;    // 目前怪物數量

    private void Start()
    {
        InvokeRepeating("CheckMonsterCount", 0f, checkInterval);
    }

    // 檢查怪物數量並控制生成或移除怪物
    private void CheckMonsterCount()
    {
        int activeMonsters = CountActiveMonsters();

        if (activeMonsters < maxMonsterCount)
        {
            int monstersToSpawn = maxMonsterCount - activeMonsters;
            Debug.Log("需要生成 " + monstersToSpawn + " 個怪物");
            SpawnMonsters(monstersToSpawn);
        }
        else if (activeMonsters > maxMonsterCount)
        {
            int monstersToDespawn = activeMonsters - maxMonsterCount;
            Debug.Log("需要移除 " + monstersToDespawn + " 個怪物");
            DespawnMonsters(monstersToDespawn);
        }
        else
        {
            Debug.Log("怪物數量已達到最大限制");
        }
    }

    // 計算場景中活躍的怪物數量
    private int CountActiveMonsters()
    {
        GameObject[] activeMonsters = GameObject.FindGameObjectsWithTag("Monster");
        return activeMonsters.Length;
    }

    // 生成指定數量的怪物
    private void SpawnMonsters(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (spawnPoints.Length == 0)
                return;

            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(monsterPrefab, spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);
        }
    }

    // 移除指定數量的怪物
    private void DespawnMonsters(int count)
    {
        GameObject[] activeMonsters = GameObject.FindGameObjectsWithTag("Monster");

        if (count > activeMonsters.Length)
            count = activeMonsters.Length;

        for (int i = 0; i < count; i++)
        {
            int randomMonsterIndex = Random.Range(0, activeMonsters.Length);
            Destroy(activeMonsters[randomMonsterIndex]);
        }
    }
}
