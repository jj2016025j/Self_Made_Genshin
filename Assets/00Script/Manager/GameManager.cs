#if UNITY_EDITOR
using Unity.FPS.Game;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PortalScene
{
    Home,
    MainWorld,
    Wilderness,
    SampleScene
}

public class GameManager : Singleton<GameManager>
{
    [Header("Manager")]
    public UIManager uiManager;
    public PlayerManager playerManager;
    public MySceneManager mySceneManager;
    public CrowdManagement monsterManager;
    public ConnectionManager connectionManager;

    [Header("Parameters")]
    [Tooltip("遊戲結束後的淡出時間")]
    public float EndSceneLoadDelay = 3f;

    [Tooltip("淡出畫面的Canvas Group")]
    public CanvasGroup EndGameFadeCanvasGroup;

    [Header("Win")]
    [Tooltip("勝利後要加載的場景名稱")]
    public string WinSceneName = "WinScene";

    [Tooltip("勝利後淡出前的延遲時間")]
    public float DelayBeforeFadeToBlack = 4f;

    [Tooltip("勝利訊息")]
    public string WinGameMessage;
    [Tooltip("勝利訊息顯示前的延遲時間")]
    public float DelayBeforeWinMessage = 2f;

    [Tooltip("勝利時播放的音效")]
    public AudioClip VictorySound;

    [Header("Lose")]
    [Tooltip("失敗後要加載的場景名稱")]
    public string LoseSceneName = "LoseScene";

    public bool GameIsEnding { get; private set; }

    private float m_TimeLoadEndGameScene;
    private string m_SceneToLoad;

    private void HandleGameEnding()
    {
        float timeRatio = 1 - (m_TimeLoadEndGameScene - Time.time) / EndSceneLoadDelay;
        EndGameFadeCanvasGroup.alpha = timeRatio;

        AudioUtility.SetMasterVolume(1 - timeRatio);

        if (Time.time >= m_TimeLoadEndGameScene)
        {
            Debug.Log("加載場景: " + m_SceneToLoad);
            SceneManager.LoadScene(m_SceneToLoad);
            GameIsEnding = false;
        }
    }

    void OnAllObjectivesCompleted(AllObjectivesCompletedEvent evt)
    {
        Debug.Log("所有目標已完成");
        EndGame(true);
    }

    void OnPlayerDeath(PlayerDeathEvent evt)
    {
        Debug.Log("玩家死亡");
        EndGame(false);
    }

    void EndGame(bool win)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameIsEnding = true;
        EndGameFadeCanvasGroup.gameObject.SetActive(true);

        if (win)
        {
            HandleWinScenario();
        }
        else
        {
            HandleLoseScenario();
        }
    }

    private void HandleWinScenario()
    {
        Debug.Log("遊戲勝利");

        m_SceneToLoad = WinSceneName;
        m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay + DelayBeforeFadeToBlack;

        var audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = VictorySound;
        audioSource.playOnAwake = false;
        audioSource.outputAudioMixerGroup = AudioUtility.GetAudioGroup(AudioUtility.AudioGroups.HUDVictory);
        audioSource.PlayScheduled(AudioSettings.dspTime + DelayBeforeWinMessage);

        DisplayMessageEvent displayMessage = Events.DisplayMessageEvent;
        displayMessage.Message = WinGameMessage;
        displayMessage.DelayBeforeDisplay = DelayBeforeWinMessage;
        EventManager.Broadcast(displayMessage);
    }

    private void HandleLoseScenario()
    {
        Debug.Log("遊戲失敗");

        m_SceneToLoad = LoseSceneName;
        m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;
    }

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
        // 訂閱事件
        EventManager.AddListener<AllObjectivesCompletedEvent>(OnAllObjectivesCompleted);
        EventManager.AddListener<PlayerDeathEvent>(OnPlayerDeath);

        // 在遊戲一開始，根據 GameState 的狀態來判斷遊戲是否開始。
        if (State == GameState.LoadGame)
        {
            Debug.Log("遊戲載入完畢，開始遊戲");
            StartGame();
        }
        else
        {
            Debug.Log("遊戲準備開始");
            PauseGame();
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
        
        AudioUtility.SetMasterVolume(1);
    }

    void Update()
    {
        // 每一帧检查是否按下了 P 键，若按下了就切换时间缩放。
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleTimeScale();
        }

        if (GameIsEnding)
        {
            HandleGameEnding();
        }
    }

    public void PauseGame()
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
            PauseGame();
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

    void OnDestroy()
    {
        // 取消訂閱事件
        EventManager.RemoveListener<AllObjectivesCompletedEvent>(OnAllObjectivesCompleted);
        EventManager.RemoveListener<PlayerDeathEvent>(OnPlayerDeath);
    }
}