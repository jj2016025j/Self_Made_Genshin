using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNormalMove : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, smoothing);
            }
        }
    }
}
