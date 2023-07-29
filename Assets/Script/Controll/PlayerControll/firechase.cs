using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firechase : MonoBehaviour//只會追擊敵人
{
    public GameObject myself;
    public GameObject target;
    public float distance;
    public float lookatdistance;//視野攻擊距離
    public float movespeed;//移動速度
    public float damping;//轉動量調整
    public Quaternion rotation;
    public Vector3 startvecter;
    void Start()
    {
        lookatdistance = 30;
        damping = 10;
        movespeed = 100;
        Destroy(gameObject, 5);
        transform.parent = null;
        transform.LookAt(myself.transform.position);
    }
    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);//計算距離
        transform.Translate(-Vector3.forward * Time.deltaTime * movespeed);//飛行
        
        if (distance < lookatdistance)
        {
            Attack();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Player")
        {
            Destroy(gameObject);
            Debug.Log(collision.transform.name);
        }
    }
    void Attack()
    {
        rotation = Quaternion.LookRotation(transform.position - target.transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}
