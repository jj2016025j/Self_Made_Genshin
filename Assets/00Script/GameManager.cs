using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

//��������
public enum PortalScene
{
    Home,
    MainWorld,
    Wilderness,
    SampleScene
}


// �C���޲z��
// ����C���i�{
// �����ഫ
public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public PlayerManager playerManager;
    public SceneManager sceneManager;
    public ConnectionManager connectionManager;

    //��e�C�����A
    public enum GameState
    {
        loadGame,
        waitingToEnterTheGame,
        SelectCharacter,
    }

    public GameState State;

    //�P�_�O�_�}�l�C��
    public void Awake()
    {
        if (State == GameState.loadGame)
        {
            Debug.Log("�C�����J�����A�}�l�C��");
            StartGame();
        }
        else
        {
            Debug.Log("�C���ǳƶ}�l");
            ReadyToStart();
        }
    }

    //��l��
    void Start()
    {
        // ���æ۰ʽ��
        uiManager = GameObject.FindObjectOfType<UIManager>();
        playerManager = GameObject.FindObjectOfType<PlayerManager>();
        sceneManager = GameObject.FindObjectOfType<SceneManager>();
        connectionManager = GameObject.FindObjectOfType<ConnectionManager>();

        // �T�O���F�o�Ǹ}��
        Debug.Assert(uiManager != null, "����� UIManager �}��");
        Debug.Assert(playerManager != null, "����� PlayerManager �}��");
        Debug.Assert(sceneManager != null, "����� SceneManager �}��");
        Debug.Assert(connectionManager != null, "����� ConnectionManager �}��");
    }    
    
    //�����ɶ��Y�����
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleTimeScale();
        }
    }

    // �C���ǳƤ�
    public void ReadyToStart()
    {
        Time.timeScale = 0;
        Debug.Log("�ɶ��Y��G0");
        //UNDO UIManager.IntoTheGame();
    }

    // �C���}�l
    public void StartGame()
    {
        Time.timeScale = 1;
        Debug.Log("�ɶ��Y��G1");
        //UNDO UIManager.StartGame();
    }

    // �ɶ��Y�����
    private void ToggleTimeScale()
    {
        if (Time.timeScale == 0f)
        {
            StartGame();
        }
        else if (Time.timeScale == 1f)
        {
            Time.timeScale = 0.5f;
            Debug.Log("�ɶ��Y��G0.5");
        }
        else
        {
            ReadyToStart();
        }
    }

    // ���}�C��
    public void QuitGame()
    {
        Debug.Log("�C������");
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    //�ಾ���a����
    public void TeleportPlayer(PortalScene destinationScene)
    {
        string destinationSceneName = destinationScene.ToString();
        var scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(destinationSceneName);

        // �ˬd�����O�_�w�g�Q���J
        if (scene.isLoaded)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(destinationSceneName);
            Debug.Log("���a�ǰe�ܳ����G" + destinationSceneName);
        }
        else
        {
            Debug.LogError("���ո��J���������s�b�G" + destinationSceneName);
        }
    }
}
