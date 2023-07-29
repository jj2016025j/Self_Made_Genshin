using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class playercontrollvariablejoystick2  : MonoBehaviour
{
    //列入使用
    //轉向移動方向
    public float fMoveSpeed = 30; //移動速度
    public VariableJoystick variableJoystick;
    void Start() { }

    void FixedUpdate()
    {
        
    }

    public void PlayerControl()

    {
        float x = Input.GetAxis("Horizontal");

        float y = Input.GetAxis("Vertical");

        if (x != 0 || y != 0)

        {

            Vector3 target = transform.position + new Vector3(x, 0, y);

            transform.LookAt(target);

            transform.Translate(Vector3.forward * Time.deltaTime * fMoveSpeed);

        }
        if (x == 0 & y == 0)
        {
            x = variableJoystick.Vertical;
            y = variableJoystick.Horizontal;
            if (x != 0 || y != 0)

            {

                Vector3 target = transform.position + Vector3.forward * x + Vector3.right * y;

                transform.LookAt(target);

                //Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
                transform.Translate(Vector3.forward * Time.deltaTime * fMoveSpeed);
            }
        }
    }
}