using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

//場景種類
public enum PortalScene
{
    Home,
    MainWorld,
    Wilderness,
    SampleScene
}


// 遊戲管理器
// 控制遊戲進程
// 場景轉換
public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public PlayerManager playerManager;
    public SceneManager sceneManager;
    public ConnectionManager connectionManager;

    //當前遊戲狀態
    public enum GameState
    {
        loadGame,
        waitingToEnterTheGame,
        SelectCharacter,
    }

    public GameState State;

    //判斷是否開始遊戲
    public void Awake()
    {
        if (State == GameState.loadGame)
        {
            Debug.Log("遊戲載入完畢，開始遊戲");
            StartGame();
        }
        else
        {
            Debug.Log("遊戲準備開始");
            ReadyToStart();
        }
    }

    //初始化
    void Start()
    {
        // 找到並自動賦值
        uiManager = GameObject.FindObjectOfType<UIManager>();
        playerManager = GameObject.FindObjectOfType<PlayerManager>();
        sceneManager = GameObject.FindObjectOfType<SceneManager>();
        connectionManager = GameObject.FindObjectOfType<ConnectionManager>();

        // 確保找到了這些腳本
        Debug.Assert(uiManager != null, "未找到 UIManager 腳本");
        Debug.Assert(playerManager != null, "未找到 PlayerManager 腳本");
        Debug.Assert(sceneManager != null, "未找到 SceneManager 腳本");
        Debug.Assert(connectionManager != null, "未找到 ConnectionManager 腳本");
    }    
    
    //偵測時間縮放切換
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleTimeScale();
        }
    }

    // 遊戲準備中
    public void ReadyToStart()
    {
        Time.timeScale = 0;
        Debug.Log("時間縮放：0");
        //UNDO UIManager.IntoTheGame();
    }

    // 遊戲開始
    public void StartGame()
    {
        Time.timeScale = 1;
        Debug.Log("時間縮放：1");
        //UNDO UIManager.StartGame();
    }

    // 時間縮放切換
    private void ToggleTimeScale()
    {
        if (Time.timeScale == 0f)
        {
            StartGame();
        }
        else if (Time.timeScale == 1f)
        {
            Time.timeScale = 0.5f;
            Debug.Log("時間縮放：0.5");
        }
        else
        {
            ReadyToStart();
        }
    }

    // 離開遊戲
    public void QuitGame()
    {
        Debug.Log("遊戲結束");
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    //轉移玩家場景
    public void TeleportPlayer(PortalScene destinationScene)
    {
        string destinationSceneName = destinationScene.ToString();
        var scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(destinationSceneName);

        // 檢查場景是否已經被載入
        if (scene.isLoaded)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(destinationSceneName);
            Debug.Log("玩家傳送至場景：" + destinationSceneName);
        }
        else
        {
            Debug.LogError("嘗試載入的場景不存在：" + destinationSceneName);
        }
    }
}
