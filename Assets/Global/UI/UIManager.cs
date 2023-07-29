using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//管理UI管理Panel管理Button
//Button 
public class UIManager : Singleton<UIManager>
{
    [Header("UI")]
    public GameManager gameManager;
    public UIManager uiManager;
    public PlayerUIManager playerUIManager;

    public MapUIManager mapUIManager;
    public BagUIManager bagUIManager;
    public BattleUIManager battleUIManager;
    public SettingUIManager settingUIManager;

    //Tooltip是備註
    [Tooltip("備註")]
    public Button StartButton, ExitButton;

    private void Awake()
    {
        //DontDestroyOnLoad(this);
        gameManager = GetComponent<GameManager>();
        uiManager = GetComponent<UIManager>();
        playerUIManager = GetComponent<PlayerUIManager>();

        mapUIManager = GameObject.Find("MapUIManager"). GetComponent<MapUIManager>();
        bagUIManager = GameObject.Find("BagUIManager"). GetComponent<BagUIManager>();
        battleUIManager = GameObject.Find("BattleUIManager").GetComponent<BattleUIManager>();
        settingUIManager = GameObject.Find("SettingUIManager").GetComponent<SettingUIManager>();

        StartButton = GameObject.Find("StartButton").GetComponent<Button>();
        ExitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        
        StartButton.onClick.AddListener(() => StartGame());
        ExitButton.onClick.AddListener(() => ExitGame());
    }
    private void Start()
    {
        battleUIManager.gameObject.SetActive(false);
        mapUIManager.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        bagUIManager.gameObject.SetActive(true);
        mapUIManager.gameObject.SetActive(true);
        battleUIManager.gameObject.SetActive(true);
        settingUIManager.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        gameManager.QuitGame();
    }
}
