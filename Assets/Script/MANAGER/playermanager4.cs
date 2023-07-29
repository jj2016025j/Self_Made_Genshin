using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

namespace Com.ABCDE.MyApp
{
    public class playermanager4 : MonoBehaviourPunCallbacks,IPunObservable
    {
        [Tooltip("���a���⪺ instance")]
        public static GameObject LocalPlayerInstance;
        [Tooltip("���a����q")]
        public float Health = 1f;
        [Tooltip("����- GameObject Beams")]
        [SerializeField]
        private GameObject beams;
        bool IsFiring;

        void Awake()
        {
            // �O�����a���⪺ instance, �קK�b����������, �S�A�ͦ��@��
            if (photonView.IsMine)
            {
                PlayerManager.LocalPlayerInstance = this.gameObject;
            }

            // �е����a���⪺ instance ���|�b���������ɳQ�����
            DontDestroyOnLoad(this.gameObject); 
            if (beams == null)
            {
                Debug.LogError(
           "<Color=Red><a>����- GameObject Beams ���ŭ�</a></Color>",
           this);
            }
            else
            {
                beams.SetActive(false);
            }
        }
        void Start()
        {
            CameraWork _cameraWork =
                this.gameObject.GetComponent<CameraWork>();

            if (_cameraWork != null)
            {
                if (photonView.IsMine)
                {
                    _cameraWork.OnStartFollowing();
                }
            }
            else
            {
                Debug.LogError("playerPrefab- CameraWork component ��",
                    this);
            }
        }
        void Update()
        {
            if (photonView.IsMine)
            {
                ProcessInputs();
            }
            ProcessInputs();
            if (beams != null && IsFiring != beams.activeSelf)
            {
                beams.SetActive(IsFiring);
            }
            if (Health <= 0f)
            {
                gamemanager.Instance.LeaveRoom();
            }
        }

        void ProcessInputs()
        {
            // ���U�o�g�s
            if (Input.GetButtonDown("Fire1"))
            {
                if (!IsFiring)
                {
                    IsFiring = true;
                }
            }
            // ��}�o�g�s
            if (Input.GetButtonUp("Fire1"))
            {
                if (IsFiring)
                {
                    IsFiring = false;
                }
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (!photonView.IsMine)
            {
                return;
            }
            if (!other.name.Contains("Beam"))
            {
                return;
            }
            Health -= 0.1f;
        }

        void OnTriggerStay(Collider other)
        {
            if (!photonView.IsMine)
            {
                return;
            }
            if (!other.name.Contains("Beam"))
            {
                return;
            }
            Health -= 0.1f * Time.deltaTime;
        }
        public void OnPhotonSerializeView(PhotonStream stream,
    PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                // �����a���H�����A, �N IsFiring �����A��s����L���a
                stream.SendNext(IsFiring);
                stream.SendNext(Health);
            }
            else
            {
                // �D�����a���H�����A, ��±�����s�����
                this.IsFiring = (bool)stream.ReceiveNext();
                this.Health = (float)stream.ReceiveNext();
            }
        }
    }
}