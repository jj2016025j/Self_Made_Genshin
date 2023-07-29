using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

//場景種類
public enum PortalScene
{
    Home,
    MainWorld,
    Wilderness
}

//當前遊戲狀態
public enum GameState
{
    waitingToEnterTheGame,
    SelectCharacter,
    loadGame
}

// 遊戲管理器
// 控制遊戲進程
// 場景轉換
public class GameManager : Singleton<GameManager>
{
    public UIManager UIManager;
    public PlayerManager PlayerManager;
    public SceneManager SceneManager;
    public ConnectionManager ConnectionManager;

    public GameObject characterPrefab;  // 角色的預置物
    public Transform spawnPoint;        // 角色生成點的位置


    public GameState State;
    public bool FirstGame;//是否是第一次遊戲

    //判斷是否開始遊戲
    public override void Awake()
    {
        base.Awake();
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
        UIManager.IntoTheGame();
    }

    // 遊戲開始
    public void StartGame()
    {
        Time.timeScale = 1;
        Debug.Log("時間縮放：1");
        UIManager.StartGame();
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

    //生成玩家角色
    public void SpawnCharacter()
    {
        Instantiate<GameObject>(characterPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("生成角色");

        // 在這裡可以對生成的角色進行進一步的設定和初始化
    }
}
