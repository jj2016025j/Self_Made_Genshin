using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadfuntion : MonoBehaviour
{
    public Transform dead;
    private void Start()
    {
        datonate();
    }
    void datonate()
    {
        dead = Instantiate(dead, transform.position, transform.rotation);
        CopyTransformRecurse(transform, dead);
    }
    void CopyTransformRecurse(Transform src, Transform dst)
    {
        dst.position = src.position;
        dst.rotation = src.rotation;
        foreach (Transform child in dst)
        {
            var curSrc = src.Find(child.name);
            if (curSrc)
            {
                CopyTransformRecurse(curSrc, child);
            }
        }
    }
        private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 30);
    }

}