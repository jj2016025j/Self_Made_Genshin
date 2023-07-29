using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject : MonoBehaviour
{
    // Awake在物件生成時先於Start執行，常常用來做初始化的動作
    void Awake()
    {
        Debug.Log("物件 " + gameObject.name + " 被生成");
        // TODO: 初始化物件的狀態
    }

    // Start是在第一幀更新前執行，用來初始化遊戲變數
    void Start()
    {
        Debug.Log("物件 " + gameObject.name + " 的Start被執行");
        // TODO: 初始化物件的狀態
    }

    // Update在每一幀被調用，常用來處理遊戲邏輯
    void Update()
    {
        Debug.Log("物件 " + gameObject.name + " 的Update被執行");
        // TODO: 更新物件的行為或狀態
    }

    // 當物件被玩家交互時被呼叫
    public void Interact()
    {
        Debug.Log("物件 " + gameObject.name + " 被交互");
        // TODO: 處理當物件被玩家交互時的行為
    }

    // 當物件被銷毀時被呼叫
    public void DestroyObject()
    {
        Debug.Log("物件 " + gameObject.name + " 被銷毀");
        // TODO: 處理當物件被銷毀時的行為
        Destroy(gameObject);  // 銷毀此遊戲物件
    }
}
