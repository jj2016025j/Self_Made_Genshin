using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//�޲z�Ҧ�Manager�C���y�{
public class GameManager : MonoBehaviour
{
    GameObject UIManager;
    public PlayerManager playerManager;

    //�h�X�C��
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
