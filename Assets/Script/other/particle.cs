using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(destory), 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void destory()
    {
        Destroy(gameObject);
    }
}
