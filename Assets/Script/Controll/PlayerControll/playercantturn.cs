using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class playercantturn5 : MonoBehaviour//自身不會轉向
{
    //對自身方向給力 會被轉向

        public float speed;

        // Use this for initialization

        void Start()
        {

            speed = 10f;

        }



        // Update is called once per frame

        void Update()
        {

            float vertical = Input.GetAxis("Vertical");

            float horizontal = Input.GetAxis("Horizontal");

            transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * speed);//注意參數，只傳入一個vector是不行的

        }
    
}