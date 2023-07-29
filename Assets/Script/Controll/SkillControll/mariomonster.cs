using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mariomonster : MonoBehaviour//類似馬力歐怪物
{
    //怪物左右移動 撞到物體會轉向 從上面踩到會刪除物件
    public float speed = 1;
    int moveDir = 1;
    Animator myAnimator;
    void Start()
    {
        //myAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        transform.Translate(Vector3.right * speed * moveDir * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 co_dir = collision.contacts[0].normal;

        float angle_right = Vector3.Angle(Vector3.right, co_dir);
        float angle_left = Vector3.Angle(Vector3.left, co_dir);
        float angle_down = Vector3.Angle(Vector3.down, co_dir);
        if (angle_right < 45)
        {
            moveDir = 1;
        }

        if (angle_left < 45)
        {
            moveDir = -1;
        }

        if (angle_down < 45)
        {
            //myAnimator.Play("enemy_die");
            //Destroy(gameObject, 0.1f);
        }
        foreach (ContactPoint contact in collision.contacts)//這段沒懂
        {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            // Visualize the contact point
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}
