using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float speed = 1.0f;
    private float time;
    private float journeyLenght;//��{����

    var i = 1;//var�i�H�w�q�ܶq�B��ơB��H
    var i = "str";
    var i = true;
    var i = funstion();
    var i = {1:2,2:4,4:8);


    void Start()
    {
        time = Time.time;//�w�q�ɶ�(���ڤ����D���ƻ��)
        journeyLenght = Vector3.Distance(start.position, end.position);//�p��_�I���I�Z��(distance�Z��
    }

    void Update()
    {
        transform.LookAt(end);
        float disCovered = (Time.time - time) * speed;
        float fracjourney = disCovered / journeyLenght;//�`�����X�����X=����(�X����)/���l(�`��)
        transform.position = Vector3.Lerp(start.position, end.position, fracjourney);//��m=�s��m.�ƶ�����(�_�l�I�A���I�A���ʳt��(���O�`�����H���ƪ���m))
    }
}