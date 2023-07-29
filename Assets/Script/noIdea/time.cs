using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    float time_f;
    int time_i;
    void Update()
    {
        //time_f = Time.time;
        time_f += Time.deltaTime;
        time_i = Mathf.FloorToInt(time_f);
        Debug.Log(time_i);
    }
}
