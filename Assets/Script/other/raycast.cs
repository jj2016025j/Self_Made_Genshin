using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PhysicsModule;

public class raycast : MonoBehaviour//版本問題
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHIT hit;
        if (physics.Raycast(startPoint, position, out this, ctor.distance + 0.2f, hitLayer)) 
        {
            ctor.distance = Mathf.Clamp(this.distance - 0.2f, 0.3f, startDis);
        }
        Debug.DrawRay(startPoint, position, Color.green)
    }
}
