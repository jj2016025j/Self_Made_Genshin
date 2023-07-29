#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public enum PortalScene
{
    Home,
    MainWorld,
    Wilderness,
    SampleScene
}

public class GameManager : Singleton<GameManager>
{
    public UIManager uiManager;
    public PlayerManager playerManager;
    public MySceneManager mySceneManager;
    public CrowdManagement monsterManager;
    public ConnectionManager connectionManager;

    public enum GameState
    {
        LoadGame,
        WaitingToEnterTheGame,
        SelectCharacter,
    }
    public GameState State;

    public override void Awake()
    {
        base.Awake();

        // 在遊戲一開始，根據 GameState 的狀態來判斷遊戲是否開始。
        if (State == GameState.LoadGame)
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

    void Start()
    {
        // 找到並自動賦值給各種管理器。
        uiManager = GameObject.FindObjectOfType<UIManager>();
        playerManager = GameObject.FindObjectOfType<PlayerManager>();
        mySceneManager = GameObject.FindObjectOfType<MySceneManager>();
        monsterManager = GameObject.FindObjectOfType<CrowdManagement>();
        connectionManager = GameObject.FindObjectOfType<ConnectionManager>();

        // 確保找到了這些腳本
        Debug.Assert(uiManager != null, "未找到 UIManager 腳本");
        Debug.Assert(playerManager != null, "未找到 PlayerManager 腳本");
        Debug.Assert(mySceneManager != null, "未找到 MySceneManager 腳本");
        Debug.Assert(monsterManager != null, "未找到 MonsterManager 腳本");
        Debug.Assert(connectionManager != null, "未找到 ConnectionManager 腳本");
    }

    void Update()
    {
        // 每一帧检查是否按下了 P 键，若按下了就切换时间缩放。
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleTimeScale();
        }
    }

    public void ReadyToStart()
    {
        // 遊戲準備開始，時間縮放設為 0
        Time.timeScale = 0;
        Debug.Log("時間縮放：0");
        // TODO: 调用 UIManager 的相关方法
    }

    public void StartGame()
    {
        // 遊戲開始，時間縮放設為 1
        Time.timeScale = 1;
        Debug.Log("時間縮放：1");
        // TODO: 调用 UIManager 的相关方法
    }

    private void ToggleTimeScale()
    {
        // 切換時間縮放
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

    public void QuitGame()
    {
        Debug.Log("遊戲結束");
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}