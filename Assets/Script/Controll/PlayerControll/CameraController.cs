using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform playerbody;
    public float sensitivity = 500f;
    float xRotation=0f;
    
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;//隱藏鼠標
        playerbody = gameObject.transform.parent;
    }
    void Update()
    {
        // 滾輪實現鏡頭縮排和拉遠
        //滑鼠右鍵實現視角轉動，類似第一人稱視角
        float MouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;//滑鼠位置
        float MouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//鎖定旋轉角度
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//其中一個要用歐拉角不然會偏掉

        playerbody.Rotate(Vector3.up * MouseX);//水平轉動
        if (Input.GetMouseButton(1))//滑鼠右鍵
        {
            
        }
    }
}
