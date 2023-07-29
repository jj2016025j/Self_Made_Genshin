using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rb1 : MonoBehaviour
{
	public float speed = 1;

	public float jumpSpeed = 10;

	public float gravity = 20;

	public float margin = 0.1f;

	private Vector3 moveDirection = Vector3.zero;


	// 通過射線檢測主角是否落在地面或者物體上
	bool IsGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, margin);
	}

	// Update is called once per frame
	void Update()
	{
		// 控制移動
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		if (IsGrounded())
		{
			moveDirection = new Vector3(h, 0, v);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			// 空格鍵控制跳躍
			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		//controller.Move(moveDirection * Time.deltaTime);
	}
}
