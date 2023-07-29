using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using Photon.Realtime;
//Photon3
public class roomSceneManager : MonoBehaviourPunCallbacks
{
    public Text textRoomName;
    [SerializeField] 
    Text textPlayerList;
    [SerializeField]
    Button buttonStartGame;
    [SerializeField]
    Button buttonLeaveGame;
    void Start()
    {
        if (PhotonNetwork.CurrentRoom == null)
        {
            Debug.Log("是我啦哈哈");
            SceneManager.LoadScene("LobbyScene");
        }
        else
        {
            textRoomName.text = PhotonNetwork.CurrentRoom.Name;
            UpdatePlayerList();//教學說這行要放進else裡面

        }
        buttonStartGame.interactable = PhotonNetwork.IsMasterClient;
    }
    public void UpdatePlayerList()
    {
        StringBuilder sb = new StringBuilder();
        foreach(var kvp in PhotonNetwork.CurrentRoom.Players)
        {
            int i=new int();
            i++;
            sb.AppendLine("第"+i+"個玩家" + kvp.Value.NickName);
        }
        textPlayerList.text = sb.ToString();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }
    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }
    public void OnClickStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnClickLeaveGame()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("LobbyScene");
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
