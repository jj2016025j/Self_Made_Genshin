using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat3 : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float speed = 1.0f;
    private float time;
    private float journeyLenght;

    void Start()
    {
        time = Time.time;
        journeyLenght = Vector3.Distance(start.position, end.position);
    }

    void Update()
    {
        transform.LookAt(end);
        float disCovered = (Time.time - time) * speed;
        float fracjourney = disCovered / journeyLenght;
        transform.position = Vector3.Lerp(start.position, end.position, fracjourney);
    }
}