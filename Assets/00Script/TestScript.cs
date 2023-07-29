using System;
using UnityEngine;
using UnityEngine.SceneManagement;

//funtion
public class TestScript : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        // 找到並自動賦值
        gameManager = FindObjectOfType<GameManager>();

        // 確保找到了這些腳本
        Debug.Assert(gameManager != null, "未找到 GameManager 腳本");
    }

    //
    public void CleanAllMonster()
    {
        gameManager.monsterManager.CleanAllMonster();
    }

    internal void MonsterDie()
    {
            gameManager.monsterManager.RemoveRandomMonster();
    }

    internal void TeleportPlayer()
    {
        gameManager.mySceneManager.TeleportPlayer();
    }
}
