using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class playerdrive : MonoBehaviour//戰車用
{
    //列入使用
    //前後移動+旋轉
    public float fMoveSpeed = 3; //移動速度

    public float fRotateSpeed = 60; //旋轉速度

    void Start() { }

    void Update()
    {

        PlayerControl1();

    }

    void PlayerControl1()

    {

        //移動

        if (Input.GetKey(KeyCode.W))

        {

            transform.Translate(Vector3.forward * Time.deltaTime * fMoveSpeed);



        }

         if (Input.GetKey(KeyCode.S))

        {

            transform.Translate(Vector3.back * Time.deltaTime * fMoveSpeed);

        }

        //旋轉

        if (Input.GetKey(KeyCode.D))

        {

            transform.Rotate(Vector3.up * Time.deltaTime * fRotateSpeed);

        }

         if (Input.GetKey(KeyCode.A))

        {

            transform.Rotate(Vector3.down * Time.deltaTime * fRotateSpeed);

        }

    }

}