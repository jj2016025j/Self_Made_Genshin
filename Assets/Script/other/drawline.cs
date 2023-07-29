using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawline : MonoBehaviour//從物件發射
{
    public Vector3 dir;
    public Vector3 movedir;
    public Vector3 moveToPos;
    public GameObject targetTrans;
    public int distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dir = targetTrans.transform.position - transform.position;
        movedir = dir.normalized * distance;
        moveToPos = transform.position + movedir;
        Debug.DrawLine(transform.position, moveToPos, Color.red);
        Debug.DrawRay(transform.position, moveToPos, Color.green);
    }
}
