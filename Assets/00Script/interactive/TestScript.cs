using System;
using UnityEngine;
using UnityEngine.SceneManagement;

//funtion
public class TestScript : MonoBehaviour
{
    public GameManager gameManager = null;
    public SceneManager sceneManager = null;

    void Start()
    {
        // 找到並自動賦值
        gameManager = GameObject.FindObjectOfType<GameManager>();

        // 確保找到了這些腳本
        Debug.Assert(gameManager != null, "未找到 GameManager 腳本");

        // 確保找到了 sceneManager
        Debug.Assert(gameManager.sceneManager != null, "GameManager 中的 sceneManager 為 null");
    }

    // 當您在Inspector中點擊按鈕時將會呼叫此方法，在這裡您可以撰寫任何您需要的測試功能
    public void CleanAllMonster()
    {
        try
        {
            // 如果 gameManager 或 gameManager.sceneManager 為 null，則這將拋出 NullReferenceException
            gameManager.sceneManager.CleanAllMonster();
        }
        catch (NullReferenceException e)
        {
            // 捕獲並處理 NullReferenceException
            Debug.Log("Caught a NullReferenceException: " + e.Message);
            Debug.Log("GameManager 或 GameManager 中的 sceneManager 為 null");
        }
    }

    internal void MonsterDie()
    {
        Monster monster = FindObjectOfType<Monster>();
        if (monster != null)
        {
            monster.Die();
        }
        else
        {
            Debug.Log("沒有找到任何 Monster 物件");
        }
    }

    internal void TeleportPlayer()
    {
        Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        // 重新加载当前场景
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
        Debug.Log("載入" + currentScene.name);
    }
}
