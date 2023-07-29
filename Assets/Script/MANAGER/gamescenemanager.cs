using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamescenemanager : MonoBehaviour
{
    [SerializeField]
    Button loadRoomScene;
    [SerializeField]
    Button loadLobbyScene;


    void Start()
    {
        if (PhotonNetwork.CurrentRoom == null)
        {
            SceneManager.LoadScene("LobbyScene");
        }
        else
        {
            StartGame();
            loadRoomScene.onClick.AddListener(LoadRoomScene);
            loadLobbyScene.onClick.AddListener(LoadLobbyScene);
        }

    }
    void Update()
    {
        Controll();
    }
    void StartGame()
    {
        float SpawnX = Random.Range(-5, 5);
        float SpawnZ = Random.Range(-5, 5);
        PhotonNetwork.Instantiate("player", new Vector3(SpawnX, 2, SpawnZ),Quaternion.identity);
    }
    void Controll()
    {

    }
    void LoadRoomScene()
    {
        SceneManager.LoadScene("RoomScene");
        Debug.Log("跑了");
    }
    void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
        PhotonNetwork.LeaveRoom();

    }
}
