using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcane : MonoBehaviour
{
    public float speed = 100;
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward*speed * Time.deltaTime);
    }
}
