using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test3 : MonoBehaviour
{
    Vector3 targetPosition = new Vector3(0, 0, 10);   // 目标位置
    Vector3 currentVelocity = Vector3.zero;     // 当前速度，这个值由你每次调用这个函数时被修改
    float maxSpeed = 5f;    // 选择允许你限制的最大速度
    float smoothTime = 5f;      // 达到目标大约花费的时间。 一个较小的值将更快达到目标。

	void Update()
	{
		//按下鼠标左键时响应该方法
		if (Input.GetMouseButtonDown(0))
		{
			//创建一条射线一摄像机为原点
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			//射线碰撞到游戏地形时
			if (Physics.Raycast(ray, out hit))
			{
				//立方体	
				GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
				obj.transform.position = hit.point;

			}
		}
	}
}
