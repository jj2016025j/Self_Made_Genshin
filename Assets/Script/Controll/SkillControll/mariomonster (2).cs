using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mariomonster : MonoBehaviour//不停移動怪物
{
    //怪物左右移動 撞到物體會轉向 從上面踩到會刪除物件
    public float speed = 1;
    public float turnspeed = 1;
    int moveDir = 1;
    bool direction = true;//方向
    Animator myAnimator;
    Quaternion targetRotation;
    void Start()
    {
        //myAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        if (direction)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * moveDir);
        }
        if (!direction)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * moveDir);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnspeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 co_dir = collision.contacts[0].normal;//撞到點的方向

        float angle_right = Vector3.Angle(Vector3.right, co_dir);
        float angle_left = Vector3.Angle(Vector3.left, co_dir);
        float angle_forward = Vector3.Angle(Vector3.forward, co_dir);
        float angle_back = Vector3.Angle(Vector3.back, co_dir);
        float angle_down = Vector3.Angle(Vector3.down, co_dir);
        if (angle_right < 45 || angle_left < 45)//左右被撞
        {
            direction = true;
            if (angle_right < 45)
            {
                moveDir = 1;
            }
            if (angle_left < 45)
            {
                moveDir = -1;
            }
        }
        if (angle_forward < 45 || angle_back < 45)//前後被撞
        {
            direction = false;
            if (angle_forward < 45)
            {
                moveDir = 1;
            }
            if (angle_back < 45)
            {
                moveDir = -1;
            }
        }
        if (angle_down < 45)
        {
            //myAnimator.Play("enemy_die");
            //Destroy(gameObject, 0.1f);
        }
        targetRotation = Quaternion.Euler(0, Random.Range(1, 361), 0);//隨機轉向
        foreach (ContactPoint contact in collision.contacts)//這段沒懂
        {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            // Visualize the contact point
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}
