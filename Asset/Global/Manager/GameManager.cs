using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

//Managetion Manager
//控制遊戲進程
//所有管理員的橋樑
public class GameManager : Singleton<GameManager>
{
    public UIManager UIManager;

    public SceneController SceneControll;
    
    public PlayerManager PlayerManager;

    public ConnectionManager ConnectionManager;

    public override void Awake()
    {
        base.Awake();
        ReadeyToStart();
    }

    private void Update()
    {
        //TimeScale Toggle
        Toggles();
    }

    public void ReadeyToStart()
    {
        Time.timeScale = 0;
        UIManager.IntoTheGame();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        UIManager.StartGame();
    }

    private void Toggles()
    {
        // Slow time toggle.
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Time.timeScale != 1) { Time.timeScale = 1; }
            else { Time.timeScale = 0.125f; }
        }
        // Pause toggle.
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale != 1) { Time.timeScale = 1; }
            else { Time.timeScale = 0f; }
        }
    }


    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
