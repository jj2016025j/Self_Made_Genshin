using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectfall : MonoBehaviour//掉落物  完成   差給玩家物件的資訊
{
    public Rigidbody fallobject;
    float time_f;
    int time_i;
    void Start()
    {
        //Random.Range()
        fallobject = gameObject.GetComponent<Rigidbody>();
        fallobject.AddForce(Random.Range(-2,2), 8, Random.Range(-2, 2), ForceMode.Impulse);
        fallobject.AddTorque(1000, 1000, 5000, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        time_f += Time.deltaTime;
        time_i = Mathf.FloorToInt(time_f);
        if (time_i > 100)
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
        //fallobject.constraints = RigidbodyConstraints.FreezeRotation;
        //fallobject.constraints = RigidbodyConstraints.FreezePosition;
    }
}
