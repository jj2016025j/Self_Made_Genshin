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


	// �q�L�g�u�˴��D���O�_���b�a���Ϊ̪���W
	bool IsGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, margin);
	}

	// Update is called once per frame
	void Update()
	{
		// �����
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		if (IsGrounded())
		{
			moveDirection = new Vector3(h, 0, v);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			// �Ů��䱱����D
			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		//controller.Move(moveDirection * Time.deltaTime);
	}
}
