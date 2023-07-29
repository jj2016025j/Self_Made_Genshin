using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

//Managetion Manager
public class GameManager : Singleton<GameManager>
{
    public UIManager UIManager;

    public SceneControll SceneControll;

    public MapManager MapManager;
    
    public PlayerManager PlayerManager;

    public ConnectionManager ConnectionManager;

    //Singleton

    public override void Awake()
    {
        base.Awake();// Dont destroy on reloading the scene

        ReadeyToStart();
    }
    public void ReadeyToStart()
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
}
