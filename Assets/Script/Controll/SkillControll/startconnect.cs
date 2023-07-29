﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class startconnect : MonoBehaviourPunCallbacks
{
    public void OnClickStart()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
        print("ClickStart");
    }
    public override void OnConnectedToMaster()
    {
        print("Connected");
        if(PhotonNetwork.IsConnected)
        SceneManager.LoadScene("LobbyScene");
    }
}
