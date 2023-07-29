using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetLookAt : MonoBehaviour
{
    public float speed = 2; //[1] ���鲾�ʳt��
    public Transform []target;  // [2] �ؼ�
    public float delta = 0.2f; // �~�t��
    private static int i = 0;
    
    void FixedUpdate()
    {
        moveTo();
    }
    void Start()
    {
        var tag =GameObject.FindWithTag("Player");
        Debug.Log(tag);
    }
    void moveTo()
    {
        // [3] ���s��l�ƥؼ��I
        target[i].position = new Vector3(target[i].position.x, transform.position.y, target[i].position.z);

        // [4] ������¦V�ؼ��I 
        transform.LookAt(target[i]);

        // [5] ����V�e����
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // [6] �P�_����O�_��F�ؼ��I
        if (transform.position.x > target[i].position.x - delta
            && transform.position.x < target[i].position.x + delta
            && transform.position.z > target[i].position.z - delta
            && transform.position.z < target[i].position.z + delta)
            i = (i + 1) % target.Length;
    }
}
