using System;
using UnityEngine;
using Cinemachine;
using System.Collections;
/*
public class CameraManager : MonoBehaviour
{
    public InputReader inputReader; // 輸入讀取器
    public Camera mainCamera; // 主相機
    public CinemachineFreeLook freeLookVCam; // 自由看向的虛擬相機
    public CinemachineImpulseSource impulseSource; // 衝擊源，用於震動相機
    private bool _isRMBPressed; // 右鍵是否被按下

    [SerializeField][Range(.5f, 3f)] private float _speedMultiplier = 1f; // 相機移動速度，可在遊戲設置中修改
    [SerializeField] private TransformAnchor _cameraTransformAnchor = default; // 相機變換錨點
    [SerializeField] private TransformAnchor _protagonistTransformAnchor = default; // 主角變換錨點

    [Header("Listening on channels")]
    [Tooltip("The CameraManager listens to this event, fired by protagonist GettingHit state, to shake camera")]
    [SerializeField] private VoidEventChannelSO _camShakeEvent = default; // 相機震動事件

    private bool _cameraMovementLock = false; // 相機移動鎖

    private void OnEnable()
    {
        Debug.Log("Camera Manager Enabled"); // 提示相機管理器已啟用
        // 添加事件監聽
        inputReader.CameraMoveEvent += OnCameraMove;
        inputReader.EnableMouseControlCameraEvent += OnEnableMouseControlCamera;
        inputReader.DisableMouseControlCameraEvent += OnDisableMouseControlCamera;

        _protagonistTransformAnchor.OnAnchorProvided += SetupProtagonistVirtualCamera;
        _camShakeEvent.OnEventRaised += impulseSource.GenerateImpulse;

        _cameraTransformAnchor.Provide(mainCamera.transform);
    }

    private void OnDisable()
    {
        Debug.Log("Camera Manager Disabled"); // 提示相機管理器已禁用
        // 移除事件監聽
        inputReader.CameraMoveEvent -= OnCameraMove;
        inputReader.EnableMouseControlCameraEvent -= OnEnableMouseControlCamera;
        inputReader.DisableMouseControlCameraEvent -= OnDisableMouseControlCamera;

        _protagonistTransformAnchor.OnAnchorProvided -= SetupProtagonistVirtualCamera;
        _camShakeEvent.OnEventRaised -= impulseSource.GenerateImpulse;

        _cameraTransformAnchor.Unset();
    }

    private void Start()
    {
        Debug.Log("Camera Manager Start"); // 提示相機管理器啟動
        // 如果主角已經可用，則設置相機目標
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

    // 暫時禁用鼠標控制，避免第一幀時導致相機移動
    IEnumerator DisableMouseControlForFrame()
    {
        Debug.Log("Disable Mouse Control For Frame"); // 提示暫時禁用鼠標控制
        _cameraMovementLock = true;
        yield return new WaitForEndOfFrame();
        _cameraMovementLock = false;
    }

    private void OnDisableMouseControlCamera()
    {
        Debug.Log("Mouse Control Disabled"); // 提示鼠標控制被禁用
        _isRMBPressed = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 當鼠標控制被禁用時，需要清空輸入
        // 否則最後一幀的輸入會'黏住'，直到下次動作被調用
        freeLookVCam.m_XAxis.m_InputAxisValue = 0;
        freeLookVCam.m_YAxis.m_InputAxisValue = 0;
    }

    private void OnCameraMove(Vector2 cameraMovement, bool isDeviceMouse)
    {
        Debug.Log("Camera Movement"); // 提示相機移動
        if (_cameraMovementLock)
            return;

        if (isDeviceMouse && !_isRMBPressed)
            return;

        // 如果設備是鼠標，則使用"固定的 delta time"，
        // 因為對於鼠標，我們不需要考慮幀持續時間
        float deviceMultiplier = isDeviceMouse ? 0.02f : Time.deltaTime;

        freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * deviceMultiplier * _speedMultiplier;
        freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * deviceMultiplier * _speedMultiplier;
    }

    // 提供Cinemachine目標，從包含對玩家Transform組件的引用的TransformAnchor SO獲取
    // 每次玩家重新實例化時，都會調用此方法
    public void SetupProtagonistVirtualCamera()
    {
        Debug.Log("Setup Protagonist Virtual Camera"); // 提示設置主角虛擬相機
        Transform target = _protagonistTransformAnchor.Value;

        freeLookVCam.Follow = target;
        freeLookVCam.LookAt = target;
        freeLookVCam.OnTargetObjectWarped(target, target.position - freeLookVCam.transform.position - Vector3.forward);
    }
}

public class CameraManager2 : MonoBehaviour
{
    // 直接參考主角物件
    public GameObject protagonist;

    // 使用 Unity 提供的事件類型，這可能需要其他腳本觸發這些事件
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
        // 使用直接參考的主角物件設定相機目標
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
*/