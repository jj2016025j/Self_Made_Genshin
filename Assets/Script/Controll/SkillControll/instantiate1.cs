using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate1 : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    public int a;
    public int b;
    public int c;
    public Vector3 instantiate;
    public Vector3 instantiate2;

    public void Onclick()
    {
        Instantiate(player, instantiate, Quaternion.identity);
    }

    void FixedUpdate()
    {
        Instantiate(player2, instantiate2, Quaternion.identity);
        a = Random.Range(-50, 50);
        b = 100;
        c = Random.Range(-50, 50);
        instantiate = new Vector3(a, b, c);
        instantiate2 = new Vector3(c, b, a);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
