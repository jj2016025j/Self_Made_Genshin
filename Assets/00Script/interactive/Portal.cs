using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 控制傳送門的相關邏輯
public class Portal : MonoBehaviour
{
    public PortalScene destinationScene; // 目標場景

    private bool playerInRange; // 玩家是否在傳送門範圍內

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("玩家進入"+ destinationScene.ToString()+"傳送門範圍。");
            Debug.Log("按下F鍵傳送至"+ destinationScene.ToString());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("玩家離開傳送門範圍。");
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (GameManager.Instance == null)
            {
                Debug.Log("GameManager.Instance is null");
                return;
            }
            Debug.Log("按下F鍵，正在傳送玩家至" + destinationScene.ToString() + "...");
            GameManager.Instance.TeleportPlayer(destinationScene);
        }
    }
}
