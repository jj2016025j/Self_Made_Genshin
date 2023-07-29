using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse01 : MonoBehaviour
{
    public float horizontalspeed = 2.0f;
    public float verticalspeed = 2.0f;

    // Start is called before the first frame update
    public Object a;
    public Transform b;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))//·Æ¹«¥ªÁä
        {
            Debug.Log("¨åÄy");
        }
        float h = horizontalspeed * Input.GetAxis("Mouse X");
        float v = verticalspeed * Input.GetAxis("Mouse Y");
        transform.Rotate(v, 0, 0);
        b.transform.Rotate(0, h, 0);//±±¨îª«¥ó
   
    }
}
