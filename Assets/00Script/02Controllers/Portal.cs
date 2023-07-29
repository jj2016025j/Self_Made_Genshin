using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 控制傳送門的相關邏輯
public class Portal : MonoBehaviour
{
    public GameManager gameManager;
    public PortalScene destinationScene; // 目標場景

    private bool playerInRange; // 玩家是否在傳送門範圍內

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            GameObject gameManagerObject = new GameObject("GameManager");
            gameManager = gameManagerObject.AddComponent<GameManager>();
            Debug.Log("创建了一个新的 GameManager 对象");
        }
        else
        {
            Debug.Log("已找到 GameManager 对象");
        }    }

    //玩家進入傳送門範圍
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("玩家進入"+ destinationScene.ToString()+"傳送門範圍。");
            Debug.Log("按下F鍵傳送至"+ destinationScene.ToString());
        }
    }

    //玩家離開傳送門範圍
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("玩家離開傳送門範圍。");
        }
    }

    //偵測玩家傳送功能
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (gameManager == null)
            {
                Debug.Log("GameManager.Instance is null");
                return;
            }
            Debug.Log("按下F鍵，正在傳送玩家至" + destinationScene.ToString() + "...");
            gameManager.mySceneManager.TeleportPlayer(destinationScene);
        }
    }
}
