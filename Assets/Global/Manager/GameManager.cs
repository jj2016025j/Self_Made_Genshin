using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//管理所有Manager遊戲流程
public class GameManager : MonoBehaviour
{
    GameObject UIManager;
    public PlayerManager playerManager;

    //退出遊戲
    public void QuitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }

    void Start()
    {
        UIManager = GameObject.Find("UIManager");
        playerManager = GetComponent<PlayerManager>();
    }
}
