using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenemove : MonoBehaviour
{
    [SerializeField] float move=2;
    
// Update is called once per frame
void FixedUpdate()
    {
        transform.Translate(0, move * Time.deltaTime, 0);
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
            Debug.Log("刪除");
        }
        
        
    }
}
