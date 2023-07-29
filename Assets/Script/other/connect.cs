using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using System.Text;
using UnityEngine.SceneManagement;

public class connect : MonoBehaviourPunCallbacks
{
    [SerializeField]
    InputField inputRoomName;
    [SerializeField]
    Text textRoomList;
    void Start()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        print("Lobby joined");
    }
    public string GetRoomName()
    {
        string roomName = inputRoomName.text;
        return roomName.Trim();
    }
    public void OnClickCreateRoom()
    {
        string roomName = GetRoomName();
        if (roomName.Length > 0)
        {
            PhotonNetwork.CreateRoom(roomName);
        }
        else
        {
            print("Invalid RoomName");
        }
    }
    public override void OnJoinedRoom()
    {
        print("Room Joined");
        SceneManager.LoadScene("MMO");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        StringBuilder sb = new StringBuilder();
        foreach(RoomInfo roomInfo in roomList)
        {
            if (roomInfo.PlayerCount > 0)
            {
                sb.AppendLine(" " + roomInfo.Name + " " + roomInfo.PlayerCount);
            }
        }
        textRoomList.text = sb.ToString();
    }
 }
