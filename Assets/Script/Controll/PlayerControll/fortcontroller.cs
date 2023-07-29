using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fire;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Rotate(0, x, 0);
        float y = Input.GetAxis("Vertical");
        fire.transform.Rotate(0, 0, y);
    }
}
