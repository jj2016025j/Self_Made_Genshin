using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//�޲zUI�޲zPanel�޲zButton
//Button 
public class UIManager : Singleton<UIManager>
{
    //TODO:UI�������A
    public GameManager GameManager;

    [Header("UI")]
    public MapUIManager MapUIManager;
    public BagUIManager BagUIManager;
    public SettingUIManager SettingUIManager;
    public PlayerInfomationUIManager PlayerInfomationUIManager;

    public Button SettingButton, BagButton, MapButton, PlayerInfomationButton, SceneSceneControllButton;

    public GameObject BeginUI, PlayerControllUI, SettingUI, BagUI, MapUI, PlayerInfomationUI, SceneControllUI;

    Canvas canvas;

    void Start()
    {
        canvas = new GameObject("Canvas").AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.gameObject.AddComponent<CanvasScaler>();
        canvas.gameObject.AddComponent<GraphicRaycaster>();

        CreateButton();
    }

    public void IntoTheGame()
    {
        SettingButton.gameObject.SetActive(false);
        BagButton.gameObject.SetActive(false);
        MapButton.gameObject.SetActive(false);
        PlayerInfomationButton.gameObject.SetActive(false);
        SceneSceneControllButton.gameObject.SetActive(false);

        BeginUI.SetActive(true);
        PlayerControllUI.SetActive(false);
        SettingUI.SetActive(false);
        BagUI.SetActive(false);
        MapUI.SetActive(false);
        PlayerInfomationUI.SetActive(false);
        SceneControllUI.SetActive(false);
    }

    public void StartGame()
    {
        SettingButton.gameObject.SetActive(true);
        BagButton.gameObject.SetActive(true);
        MapButton.gameObject.SetActive(true);
        PlayerInfomationButton.gameObject.SetActive(true);
        SceneSceneControllButton.gameObject.SetActive(true);
        
        BeginUI.SetActive(false);
        PlayerControllUI.SetActive(true);
        SettingUI.SetActive(false);
        BagUI.SetActive(false);
        MapUI.SetActive(false);
        PlayerInfomationUI.SetActive(true);
        SceneControllUI.SetActive(false);
    }

    public void QuitGame()
    {
        GameManager.QuitGame();
    }

    public void PlayerControllUISwitch()
    {
        PlayerControllUI.SetActive(!PlayerControllUI.activeSelf);
    }

    public void SettingUISwitch()
    {
        SettingUI.SetActive(!SettingUI.activeSelf);
    }

    public void BagUISwitch()
    {
        BagUI.SetActive(!BagUI.activeSelf);
    }

    public void MapUISwitch()
    {
        MapUI.SetActive(!MapUI.activeSelf);
    }

    public void PlayerInfomationUISwitch()
    {
        PlayerInfomationUI.SetActive(!PlayerInfomationUI.activeSelf);
    }

    public void SceneControllUISwitch()
    {
        SceneControllUI.SetActive(!SceneControllUI.activeSelf);
    }

    void CreateButton()
    {
        GameObject buttonObj = new GameObject("Button");
        buttonObj.transform.SetParent(canvas.transform);

        Button button = buttonObj.AddComponent<Button>();

        // �K�[Image Component�ó]�w�C��
        Image image = buttonObj.AddComponent<Image>();
        image.color = Color.red;

        // �K�[RectTransform�ó]�w�ؤo�M��m
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(100, 50);
        rectTransform.anchoredPosition = new Vector2(0, 0);

        // �K�[Button�I���ƥ�
        button.onClick.AddListener(() => { Debug.Log("Button clicked!"); });
    }
}
