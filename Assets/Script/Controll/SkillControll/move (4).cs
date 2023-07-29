玩家移動腳本 不過這個不好用
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class move : MonoBehaviour
{
    //列入使用
    //轉向移動方向
    float fMoveSpeed = 30; //移動速度

    float fRotateSpeed = 60; //旋轉速度

    void Start() { }

    void Update()
    {

        PlayerControl2();

    }

    void PlayerControl2()

    {

        float x = Input.GetAxis("Horizontal");

        float y = Input.GetAxis("Vertical");

        if (x != 0 || y != 0)

        {

            Vector3 target = transform.position + new Vector3(x, 0, y);

            transform.LookAt(target);

            transform.Translate(Vector3.forward * Time.deltaTime * fMoveSpeed);

        }
    }
}
