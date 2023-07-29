using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] Transform controller;
    [SerializeField] float sp;
    [SerializeField] float dis=8;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cam.position = new Vector3(Mathf.Lerp(cam.position.x, controller.position.x, sp), Mathf.Lerp(cam.position.y, controller.position.y, sp), -dis);// Mathf.Lerp(cam.position, controller.position, sp);
    }
}
