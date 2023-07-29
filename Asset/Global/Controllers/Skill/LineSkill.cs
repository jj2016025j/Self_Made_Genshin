using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSkill : SkillManager
{
    public float speed = 30.0f; // 子彈速度
    public Rigidbody rb;
    public Vector3 direction;

    void Update()
    {
        rb.AddForce((direction * speed + transform.up * 10) * Time.deltaTime, ForceMode.Impulse);

    }
}