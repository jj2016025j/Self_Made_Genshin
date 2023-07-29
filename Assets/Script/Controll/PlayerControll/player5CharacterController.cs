using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class player5CharacterController : MonoBehaviour
{
    //不知道為甚麼開始亂跳

        private CharacterController character;

        private float speed;

        void Start()
        {

            character = this.GetComponent<CharacterController>();

            speed = 1f;

        }

        // Update is called once per frame

        void Update()
        {

            MoveControl();

        }

        void MoveControl()

        {

            float horizontal = Input.GetAxis("Horizontal"); //A D 左右

            float vertical = Input.GetAxis("Vertical"); //W S 上 下


            character.SimpleMove(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime);

        }
    }