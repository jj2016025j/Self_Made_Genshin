using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotr : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);//���ܪ���ܦ�m
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);//��ӳ��O�ھڼƭ���ʧڤ�����t�b��
        gameObject.transform.rotation = transform.rotation(0, 90, 0);//��ӳ��O�ھڼƭ���ʧڤ�����t�b��
    }

    void Update()
    {
        gameobject.transform.Translate(0, 1, 0);//�[�W���w�ƭȦ�m
        gameobject.transform.Rotate(0, 1, 0);//�[�W���w�ƭ����
        gameobject.rigibody.velocity(0, 1, 0);//�ο���Ӻ�ڤ����D�t�b��
        transform.LookAt(); //���H�Y��(�ݥ��a�J
    }
 