using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rb : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float thrust;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.forward * thrust, ForceMode.Impulse);
        rigidbody.velocity = Vector3.forward * thrust;
        Destroy(gameObject, 10);

    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        rigidbody.useGravity = true;
    }
}
