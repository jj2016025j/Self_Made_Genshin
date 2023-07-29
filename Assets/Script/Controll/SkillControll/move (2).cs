using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	public int movetybe;
	//GameObject a;
	public float speed;
	public float time;
	public float mSPD;
	public Vector3 position=new Vector3(0,0,10);
	void Start () 
	{
		//this.InvokeRepeating("movestyle",0,2);
		mSPD=GameObject.Find("player").GetComponent<script>().mSPD;
		speed = 0.3f;
		time=Time.time;
		time=Time.deltaTime;
	}
	Vector3 target = new Vector3(0, 0, 10);
	Vector3 currentVelocity = Vector3.zero;
	float max = 5f;
	float smoothtime = 5f;
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetKey("up"))
        {
			Debug.Log("forward");
			transform.Translate(speed, 0, 0);
		}
		if (Input.GetKey("down"))
		{
			Debug.Log("back");
			transform.Translate(-speed, 0, 0);
		}
		if (Input.GetKey("right"))
		{
			Debug.Log("right");
			transform.Translate(0, 0, -speed);
		}
		if (Input.GetKey("left"))
		{
			Debug.Log("left");
			transform.Translate(0, 0, speed);
		}
		Input.GetAxis("Horizontal");
		transform.Translate(Vector3.forward * speed * time, Space.World);
		transform.position = Vector3.Lerp(transform.position, position, speed);
		transform.position = Vector3.Slerp(transform.position, position, speed);
		transform.position = Vector3.MoveTowards(transform.position, position, speed);
		transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, time, max);

		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
        if (x != 0 || y != 0)
        {
			Vector3 target = transform.position + new Vector3(x, 0, y);
			transform.LookAt(target);
			transform.Translate(Vector3.forward * time * speed);
		}
	}
	void movestyle()
    {
		Debug.Log("1");
		movetybe = Random.Range(1, 3);
		switch (movetybe)
		{
			case 1:
				forward();
				Debug.Log("forward");
				break;
			case 2:
				jump();
				Debug.Log("jump");
				break;
			case 3:
				rotate();
				Debug.Log("rotate");
				break;
		}
	}
	void jump()
    {
		gameObject.transform.Translate(0, 1, 0);
	}
	void rotate()
    {
		gameObject.transform.Rotate(60, 0, 0);
	}
	void forward()
    {
		gameObject.transform.Translate(1, 0, 0);
		//GameObject.Destroy(a);

	}
}

