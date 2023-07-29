using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerasmoothing : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }
}
