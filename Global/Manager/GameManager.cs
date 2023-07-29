using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

//�޲z�Ҧ�Manager�C���y�{
public class GameManager : MonoBehaviour
{
    public UIManager UIManager;

    public MapManager MapManager;
    public SkillManager SkillManager;
    public PlayerManager PlayerManager;
    public MonsterManager MonsterManager;

    public SceneControll SceneControll;

    public void StartGame()
    {
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
