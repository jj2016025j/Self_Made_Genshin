using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : Singleton<MySceneManager>
{
    public GameObject characterPrefab;  // 角色的預置物
    public Transform spawnPoint;        // 角色生成點的位置
    public CrowdManagement monsterManager; // 怪物管理器的實例

    // 遊戲開始時被呼叫
    public override void Awake()
    {
        base.Awake();
        Debug.Log("遊戲開始，初始化【角色生成】");
    }

    private void Start()
    {
        monsterManager = GameObject.FindObjectOfType<CrowdManagement>();
        spawnPoint = transform;//預設

        // 確保找到了這些腳本
        Debug.Assert(monsterManager != null, "未找到 MonsterManager 腳本");

        SpawnCharacter();  // 生成角色
    }
    // 生成玩家角色
    public void SpawnCharacter()
    {
        try
        {
            Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation); //生成角色
        }
        catch (InvalidCastException e)
        {
            Debug.Log("Caught an InvalidCastException: " + e.Message);
        }

        Debug.Log("生成角色");
        // 在這裡可以對生成的角色進行進一步的設定和初始化
    }

    //傳送玩家
    public void TeleportPlayer(PortalScene destinationScene)
    {
        string destinationSceneName = destinationScene.ToString();
        var scene = SceneManager.GetSceneByName(destinationSceneName);

        // 檢查場景是否已經被載入
        if (scene.isLoaded)
        {
            SceneManager.LoadScene(destinationSceneName);
            Debug.Log("玩家傳送至場景：" + destinationSceneName);
        }
        else
        {
            Debug.LogError("嘗試載入的場景不存在：" + destinationSceneName);
        }
    }

    internal void TeleportPlayer()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        monsterManager.CleanAllMonster();
        // 重新加载当前场景
        SceneManager.LoadScene(currentScene.name);
        Debug.Log("載入" + currentScene.name);
    }

}