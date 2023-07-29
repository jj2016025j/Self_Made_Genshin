using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float speed = 1.0f;
    private float time;
    private float journeyLenght;//行程長度

    var i = 1;//var可以定義變量、函數、對象
    var i = "str";
    var i = true;
    var i = funstion();
    var i = {1:2,2:4,4:8);


    void Start()
    {
        time = Time.time;//定義時間(但我不知道有甚麼用)
        journeyLenght = Vector3.Distance(start.position, end.position);//計算起點終點距離(distance距離
    }

    void Update()
    {
        transform.LookAt(end);
        float disCovered = (Time.time - time) * speed;
        float fracjourney = disCovered / journeyLenght;//總長的幾分之幾=分母(幾等分)/分子(總長)
        transform.position = Vector3.Lerp(start.position, end.position, fracjourney);//位置=新位置.滑順移動(起始點，終點，移動速度(其實是總長乘以分數的位置))
    }
}