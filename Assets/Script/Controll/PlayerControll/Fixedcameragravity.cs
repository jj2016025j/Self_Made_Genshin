using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class Fixedcameragravity : MonoBehaviour//可以再修改 不被父物件影響
{
    //對世界方向給力  適合給固定相機位置的移動

        // Use this for initialization

        public Rigidbody rigidbody;

    public float speed;



        void Start()
        {

            speed = 10f;

            rigidbody = this.GetComponent<Rigidbody>();

        }



        // Update is called once per frame

        void Update()
        {

            float vertical = Input.GetAxis("Vertical");

            float horizontal = Input.GetAxis("Horizontal");

            rigidbody.velocity =new Vector3(horizontal, 0, vertical) * speed; 
            
        }
    
}