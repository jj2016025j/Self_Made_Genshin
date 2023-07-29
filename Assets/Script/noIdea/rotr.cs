using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotr : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);//改變物件至位置
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);//兩個都是根據數值轉動我不知到差在哪
        gameObject.transform.rotation = transform.rotation(0, 90, 0);//兩個都是根據數值轉動我不知到差在哪
    }

    void Update()
    {
        gameobject.transform.Translate(0, 1, 0);//加上指定數值位置
        gameobject.transform.Rotate(0, 1, 0);//加上指定數值轉動
        gameobject.rigibody.velocity(0, 1, 0);//用鋼體來算我不知道差在哪
        transform.LookAt(); //跟隨某物(需先帶入
    }
 