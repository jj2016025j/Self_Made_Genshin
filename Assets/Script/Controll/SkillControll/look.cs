看目標
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameralookat : MonoBehaviour//看相目標
{
    public Transform target;
    public Vector3 distance;
    public float smoothing;

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                transform.position = Vector3.Lerp(transform.position, targetPos + distance, smoothing);
            }
        }
        transform.LookAt(-transform.forward + target.position);
    }
    void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("Main Camera").transform;
        }
    }
}

