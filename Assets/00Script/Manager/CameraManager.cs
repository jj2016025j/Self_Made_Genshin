using System;
using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public InputReader inputReader; // ��JŪ����
    public Camera mainCamera; // �D�۾�
    public CinemachineFreeLook freeLookVCam; // �ۥѬݦV�������۾�
    public CinemachineImpulseSource impulseSource; // �������A�Ω�_�ʬ۾�
    private bool _isRMBPressed; // �k��O�_�Q���U

    [SerializeField][Range(.5f, 3f)] private float _speedMultiplier = 1f; // �۾����ʳt�סA�i�b�C���]�m���ק�
    [SerializeField] private TransformAnchor _cameraTransformAnchor = default; // �۾��ܴ����I
    [SerializeField] private TransformAnchor _protagonistTransformAnchor = default; // �D���ܴ����I

    [Header("Listening on channels")]
    [Tooltip("The CameraManager listens to this event, fired by protagonist GettingHit state, to shake camera")]
    [SerializeField] private VoidEventChannelSO _camShakeEvent = default; // �۾��_�ʨƥ�

    private bool _cameraMovementLock = false; // �۾�������

    private void OnEnable()
    {
        Debug.Log("Camera Manager Enabled"); // ���ܬ۾��޲z���w�ҥ�
        // �K�[�ƥ��ť
        inputReader.CameraMoveEvent += OnCameraMove;
        inputReader.EnableMouseControlCameraEvent += OnEnableMouseControlCamera;
        inputReader.DisableMouseControlCameraEvent += OnDisableMouseControlCamera;

        _protagonistTransformAnchor.OnAnchorProvided += SetupProtagonistVirtualCamera;
        _camShakeEvent.OnEventRaised += impulseSource.GenerateImpulse;

        _cameraTransformAnchor.Provide(mainCamera.transform);
    }

    private void OnDisable()
    {
        Debug.Log("Camera Manager Disabled"); // ���ܬ۾��޲z���w�T��
        // �����ƥ��ť
        inputReader.CameraMoveEvent -= OnCameraMove;
        inputReader.EnableMouseControlCameraEvent -= OnEnableMouseControlCamera;
        inputReader.DisableMouseControlCameraEvent -= OnDisableMouseControlCamera;

        _protagonistTransformAnchor.OnAnchorProvided -= SetupProtagonistVirtualCamera;
        _camShakeEvent.OnEventRaised -= impulseSource.GenerateImpulse;

        _cameraTransformAnchor.Unset();
    }

    private void Start()
    {
        Debug.Log("Camera Manager Start"); // ���ܬ۾��޲z���Ұ�
        // �p�G�D���w�g�i�ΡA�h�]�m�۾��ؼ�
        if (_protagonistTransformAnchor.isSet)
            SetupProtagonistVirtualCamera();
    }

    private void OnEnableMouseControlCamera()
    {
        _isRMBPressed = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(DisableMouseControlForFrame());
    }

    // �ȮɸT�ι��б���A�קK�Ĥ@�V�ɾɭP�۾�����
    IEnumerator DisableMouseControlForFrame()
    {
        Debug.Log("Disable Mouse Control For Frame"); // ���ܼȮɸT�ι��б���
        _cameraMovementLock = true;
        yield return new WaitForEndOfFrame();
        _cameraMovementLock = false;
    }

    private void OnDisableMouseControlCamera()
    {
        Debug.Log("Mouse Control Disabled"); // ���ܹ��б���Q�T��
        _isRMBPressed = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // �����б���Q�T�ήɡA�ݭn�M�ſ�J
        // �_�h�̫�@�V����J�|'�H��'�A����U���ʧ@�Q�ե�
        freeLookVCam.m_XAxis.m_InputAxisValue = 0;
        freeLookVCam.m_YAxis.m_InputAxisValue = 0;
    }

    private void OnCameraMove(Vector2 cameraMovement, bool isDeviceMouse)
    {
        Debug.Log("Camera Movement"); // ���ܬ۾�����
        if (_cameraMovementLock)
            return;

        if (isDeviceMouse && !_isRMBPressed)
            return;

        // �p�G�]�ƬO���СA�h�ϥ�"�T�w�� delta time"�A
        // �]����󹫼СA�ڭ̤��ݭn�Ҽ{�V����ɶ�
        float deviceMultiplier = isDeviceMouse ? 0.02f : Time.deltaTime;

        freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * deviceMultiplier * _speedMultiplier;
        freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * deviceMultiplier * _speedMultiplier;
    }

    // ����Cinemachine�ؼСA�q�]�t�缾�aTransform�ե󪺤ޥΪ�TransformAnchor SO���
    // �C�����a���s��ҤƮɡA���|�եΦ���k
    public void SetupProtagonistVirtualCamera()
    {
        Debug.Log("Setup Protagonist Virtual Camera"); // ���ܳ]�m�D�������۾�
        Transform target = _protagonistTransformAnchor.Value;

        freeLookVCam.Follow = target;
        freeLookVCam.LookAt = target;
        freeLookVCam.OnTargetObjectWarped(target, target.position - freeLookVCam.transform.position - Vector3.forward);
    }
}

public class CameraManager2 : MonoBehaviour
{
    // �����ѦҥD������
    public GameObject protagonist;

    // �ϥ� Unity ���Ѫ��ƥ������A�o�i��ݭn��L�}��Ĳ�o�o�Ǩƥ�
    public event Action<Vector2, bool> CameraMoveEvent;
    public event Action EnableMouseControlCameraEvent;
    public event Action DisableMouseControlCameraEvent;
    public event Action CamShakeEvent;

    public Camera mainCamera;
    public CinemachineFreeLook freeLookVCam;
    public CinemachineImpulseSource impulseSource;
    private bool _isRMBPressed;

    [SerializeField][Range(.5f, 3f)] private float _speedMultiplier = 1f;
    private bool _cameraMovementLock = false;

    private void OnEnable()
    {
        CameraMoveEvent += OnCameraMove;
        EnableMouseControlCameraEvent += OnEnableMouseControlCamera;
        DisableMouseControlCameraEvent += OnDisableMouseControlCamera;
        CamShakeEvent += impulseSource.GenerateImpulse;
    }

    private void OnDisable()
    {
        CameraMoveEvent -= OnCameraMove;
        EnableMouseControlCameraEvent -= OnEnableMouseControlCamera;
        DisableMouseControlCameraEvent -= OnDisableMouseControlCamera;
        CamShakeEvent -= impulseSource.GenerateImpulse;
    }

    private void Start()
    {
        // �ϥΪ����ѦҪ��D������]�w�۾��ؼ�
        SetupProtagonistVirtualCamera();
    }

    private void OnEnableMouseControlCamera()
    {
        _isRMBPressed = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(DisableMouseControlForFrame());
    }

    IEnumerator DisableMouseControlForFrame()
    {
        _cameraMovementLock = true;
        yield return new WaitForEndOfFrame();
        _cameraMovementLock = false;
    }

    private void OnDisableMouseControlCamera()
    {
        _isRMBPressed = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        freeLookVCam.m_XAxis.m_InputAxisValue = 0;
        freeLookVCam.m_YAxis.m_InputAxisValue = 0;
    }

    private void OnCameraMove(Vector2 cameraMovement, bool isDeviceMouse)
    {
        if (_cameraMovementLock)
            return;
        if (isDeviceMouse && !_isRMBPressed)
            return;
        float deviceMultiplier = isDeviceMouse ? 0.02f : Time.deltaTime;
        freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * deviceMultiplier * _speedMultiplier;
        freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * deviceMultiplier * _speedMultiplier;
    }

    public void SetupProtagonistVirtualCamera()
    {
        Transform target = protagonist.transform;
        freeLookVCam.Follow = target;
        freeLookVCam.LookAt = target;
        freeLookVCam.OnTargetObjectWarped(target, target.position - freeLookVCam.transform.position - Vector3.forward);
    }
}
