using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class jsonload : MonoBehaviour
{

    //�ŧi�@�Ӧr��Ū���ɮסA�ŧi�@��Data����(�W�@�g�w�q���i�ΨӦs��C����T)�Ө��o�r���ഫ�᪺����
    string LoadData;
    Data MyData;
    void Start()
    {

        //Ū�����w���|��Json�ɮר��ন�r��(���|�P�W�@�g)
        LoadData = File.ReadAllText("D:/���ӦbC��/unity�m�߱M��/test01/Assets/"+"file1");

        //��r���ഫ��Data����
        MyData = JsonUtility.FromJson<Data>(LoadData);

        //�L�X���󤤪��ƭ�
        Debug.Log("���a�ͩR�� " + MyData.health);
        Debug.Log("���a������ " + MyData.money);
        Debug.Log("���a��" + MyData.equip.Count + "�Ӹ˳�");
    }
}