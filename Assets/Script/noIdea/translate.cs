using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(0, 0, 0);
    }
 // gameObject.transform.Rotate(0, 90*Time.deltaTime, 0);
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            gameObject.transform.Translate(1, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            gameObject.transform.Translate(-1, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            gameObject.transform.Translate(0, 0, 1);
        }
        if (Input.GetKey("d"))
        {
            gameObject.transform.Translate(0, 0, -1);
        }
        if (Input.GetKey("b"))
        {
            gameObject.transform.Translate(0, 1, 0);
        }
    }
}
