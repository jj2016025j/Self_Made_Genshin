using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    public bool running;
    void Start()
    {
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") && running == false)
        {
            GetComponent<Animation>().Play("running");
            running = true;
        }
        else if(Input.GetKey("s") && running == false)
        {
            GetComponent<Animation>().Play("running");
            running = false;
        }
    }
}
