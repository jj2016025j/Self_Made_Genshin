using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translate : MonoBehaviour
{
    public float a;
    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(0, 0, 0);
    }
 // gameObject.transform.Rotate(0, 90*Time.deltaTime, 0);
    // Update is called once per frame
    void FixedUpdate()
        
    {
       float a = 0.1f;
        if (Input.GetKey("w"))
        {
            gameObject.transform.Translate(a, 0, 0);
            //gameObject.transform.Rotate(0, 1, 0);
            //±€¬‡
        }
        if (Input.GetKey("s"))
        {
            gameObject.transform.Translate(-a, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            gameObject.transform.Translate(0, 0, a);
        }
        if (Input.GetKey("d"))
        {
            gameObject.transform.Translate(0, 0, -a);
        }
        if (Input.GetKey("b"))
        {
            gameObject.transform.Translate(0,a, 0);
        }
        if (Input.GetKey("+"))
        {
            this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);//§ÿ§o≈‹§∆
        }
        }
}
