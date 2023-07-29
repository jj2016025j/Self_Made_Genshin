using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectfall : MonoBehaviour
{
    public Rigidbody fallobject;
    float time_f;
    int time_i;
    void Start()
    {
        //Random.Range()
        fallobject = gameObject.GetComponent<Rigidbody>();
        fallobject.AddForce(0, 10, 0, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        time_f += Time.deltaTime;
        time_i = Mathf.FloorToInt(time_f);
        Debug.Log(time_i);
        if (time_i > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        
    }
}
