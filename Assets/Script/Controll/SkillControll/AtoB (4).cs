using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class AtoB : MonoBehaviour
{
    //http://aetherchang.blogspot.com/2017/03/unity-3d.html
    //列入使用
    //用於A到B 以距離算
    public Transform start;
    public Transform end;
    public float speed;//速度
    public float distance;//距離
    public float high;//高度
    public int type;//種類
    //避免開始點越拉越長 固定開始點變數
    private void Start()
    {
        start = GetComponent<AtoB>().transform;
        end = GameObject.FindGameObjectWithTag("Player").transform;
        if (speed == 0)
        {
            speed = 3;
        }
        if (distance == 0)
        {
            distance = 0.1f;
        }
        if (high == 0)
        {
            high = 5;
        }
    }
    void Update()
    {
        parabola();
    }
    void Lerp()//以比例算 直線
    {
        transform.position = Vector3.Lerp(start.position, end.position, Time.time * distance);//
    }
    void MoveTowards()////以速度、距離算 直線
    {
        transform.position = Vector3.MoveTowards(start.position, end.position, speed * Time.deltaTime);
    }
    void parabola()//拋物線
    {
        Vector3 center = start.position + end.position / 100;
        Debug.Log(center);
        Debug.Log(start.position);
        Debug.Log(end.position);
        center -= new Vector3(0, high, 0);
        Vector3 riseRelCenter = start.position - center;
        Vector3 setRelCenter = end.position - center;
        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, Time.time * distance);
        transform.position += center;
    }
}