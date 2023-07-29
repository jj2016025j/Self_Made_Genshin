using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

//管理所有Manager遊戲流程
public class GameManager : MonoBehaviour
{
    public UIManager UIManager;

    public MapManager MapManager;
    public SkillManager SkillManager;
    public PlayerManager PlayerManager;
    public MonsterManager MonsterManager;

    public SceneControll SceneControll;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        UIManager.StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
