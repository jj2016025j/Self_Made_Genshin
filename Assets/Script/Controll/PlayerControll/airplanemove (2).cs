using System.Collections;

using System.Collections.Generic;

using UnityEngine;
//http://aetherchang.blogspot.com/2017/03/unity-3d.html
//飛機移動方式
//列入少數使用
public class airplanemove : MonoBehaviour
{
    /// <summary>移動速度</summary>
    public float fMoveSpeed = 100.0f;
    /// <summary>旋轉速度</summary>
    public float fRotateSpeed = 5.0f;

    void Update()
    {
        //上下旋轉
        float l_fH = Input.GetAxis("Mouse X") * fRotateSpeed;
        transform.Rotate(Vector3.up * Time.deltaTime * l_fH * 100);
        //左右旋轉
        float l_fV = Input.GetAxis("Mouse Y") * fRotateSpeed;
        transform.Rotate(Vector3.left * Time.deltaTime * l_fV * 100);
        //往前移動
        transform.Translate(Vector3.forward * Time.deltaTime * fMoveSpeed);
    }
}