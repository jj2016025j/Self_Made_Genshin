using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

//��������
public enum PortalScene
{
    Home,
    MainWorld,
    Wilderness
}

//��e�C�����A
public enum GameState
{
    waitingToEnterTheGame,
    SelectCharacter,
    loadGame
}

// �C���޲z��
// ����C���i�{
// �����ഫ
public class GameManager : Singleton<GameManager>
{
    public UIManager UIManager;
    public PlayerManager PlayerManager;
    public SceneManager SceneManager;
    public ConnectionManager ConnectionManager;

    public GameObject characterPrefab;  // ���⪺�w�m��
    public Transform spawnPoint;        // ����ͦ��I����m


    public GameState State;
    public bool FirstGame;//�O�_�O�Ĥ@���C��

    //�P�_�O�_�}�l�C��
    public override void Awake()
    {
        base.Awake();
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
        UIManager.IntoTheGame();
    }

    // �C���}�l
    public void StartGame()
    {
        Time.timeScale = 1;
        Debug.Log("�ɶ��Y��G1");
        UIManager.StartGame();
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

    //�ͦ����a����
    public void SpawnCharacter()
    {
        Instantiate<GameObject>(characterPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("�ͦ�����");

        // �b�o�̥i�H��ͦ�������i��i�@�B���]�w�M��l��
    }
}
