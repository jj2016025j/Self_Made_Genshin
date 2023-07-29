using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameralookat : MonoBehaviour//看向目標
{
    public Transform target;
    public Vector3 distance;//偏移量
    public float smoothing;//0是不移動，1是已經追到，0~1是正在跟隨

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)//如果還沒追到的話
            {
                Vector3 targetPos = target.position;//新目標位置
                transform.position = Vector3.Lerp(transform.position, targetPos + distance, smoothing);//移動到目標位置
            }
        }
        transform.LookAt(-transform.forward + target.position);//背對目標
    }
    void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("Main Camera").transform;
        }
    }
}
