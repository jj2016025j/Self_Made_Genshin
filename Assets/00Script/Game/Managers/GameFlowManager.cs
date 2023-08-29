using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.FPS.Game
{
    public class GameFlowManager : MonoBehaviour
    {
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

        void Awake()
        {
            // 訂閱事件
            EventManager.AddListener<AllObjectivesCompletedEvent>(OnAllObjectivesCompleted);
            EventManager.AddListener<PlayerDeathEvent>(OnPlayerDeath);
        }

        void Start()
        {
            AudioUtility.SetMasterVolume(1);
        }

        void Update()
        {
            if (GameIsEnding)
            {
                HandleGameEnding();
            }
        }

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

        void OnDestroy()
        {
            // 取消訂閱事件
            EventManager.RemoveListener<AllObjectivesCompletedEvent>(OnAllObjectivesCompleted);
            EventManager.RemoveListener<PlayerDeathEvent>(OnPlayerDeath);
        }
    }
}
