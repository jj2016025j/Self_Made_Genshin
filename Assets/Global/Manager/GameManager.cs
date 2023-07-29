using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

//Managetion Manager
public class GameManager : MonoBehaviour
{
    public UIManager UIManager;

    public MapManager MapManager;
    public PlayerManager PlayerManager;

    public SceneControll SceneControll;

    //流程控制
    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
    //鏡頭控制
    //AI移動
}
