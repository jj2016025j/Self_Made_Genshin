using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

namespace Com.ABCDE.MyApp
{
    public class launcher : MonoBehaviourPunCallbacks
    {
        [Tooltip("���/���� �C�����a�W�ٻP Play ���s")]
        [SerializeField]
        private GameObject controlPanel;
        [Tooltip("���/���� �s�u�� �r��")]
        [SerializeField]
        private GameObject progressLabel;
        
        [Tooltip("�C���Ǫ��a�H�ƤW��. ��C���Ǫ��a�H�Ƥw���B, �s���a�u��s�}�C���ǨӶi��C��.")]
        [SerializeField]
        private byte maxPlayersPerRoom = 4;
        public Button button;
        // �C���������s�X, �i�� Photon Server ���P�ڹC�����P�������Ϲj.
        string gameVersion = "1";
        bool isConnecting;
        void Awake()
        {
            // �T�O�Ҧ��s�u�����a�����J�ۦP���C������
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        void Start()
        {
            button.onClick.AddListener(() => Connect());
        }

        // �P Photon Cloud �s�u
        public void Connect()
        {
            isConnecting = true;
            // �ˬd�O�_�P Photon Cloud �s�u
            if (PhotonNetwork.IsConnected)
            {
                // �w�s�u, �|���H���[�J�@�ӹC����
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // ���s�u, �|�ջP Photon Cloud �s�u
                PhotonNetwork.GameVersion = gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
            progressLabel.SetActive(true);
            controlPanel.SetActive(false);
        }
        public override void OnConnectedToMaster()
        {
            Debug.Log("PUN �I�s OnConnectedToMaster(), �w�s�W Photon Cloud.");

            // �T�{�w�s�W Photon Cloud
            // �H���[�J�@�ӹC����
            if (isConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
                SceneManager.LoadScene("test");
            }
        }
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("PUN �I�s OnDisconnected() {0}.", cause);
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
        }
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN �I�s OnJoinRandomFailed(), �H���[�J�C���ǥ���.");

            // �H���[�J�C���ǥ���. �i���]�O 1. �S���C���� �� 2. ���������F.    
            // �n�a, �ڭ̦ۤv�}�@�ӹC����.
            PhotonNetwork.CreateRoom(null, new RoomOptions());
            PhotonNetwork.CreateRoom(null, new RoomOptions
            {
                MaxPlayers = maxPlayersPerRoom
            });
        }
        public override void OnJoinedRoom()
        {
            Debug.Log("PUN �I�s OnJoinedRoom(), �w���\�i�J�C���Ǥ�.");
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                Debug.Log("�ڬO�Ĥ@�Ӷi�J�C���Ǫ����a");
                Debug.Log("�ڱo�D�ʰ����J���� 'Room for 1' ���ʧ@");
                PhotonNetwork.LoadLevel("Room for 1");
            }
        }
    }
}