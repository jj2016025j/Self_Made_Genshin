using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onlychasemonster : MonoBehaviour
{
    //http://aetherchang.blogspot.com/2017/03/unity-3d.html
    //追擊目標
    //目標位置
    public Transform target;
    void Update()
    {
        if (target != null)
        {//計算兩物體的距離
            float dis = Vector3.Distance(transform.position, target.position);
            //保持距離，若遠離則追逐目標。
            if (dis > 5)
            {
                //持續注視目標
                transform.LookAt(target);
                //持續往目標前進
                transform.position += transform.forward * Time.deltaTime * 10;
            }
        }
    }
}