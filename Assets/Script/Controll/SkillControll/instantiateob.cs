using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateob : MonoBehaviour
{
    //public GameObject instantiate1;
    //�ͦ�����b�Ӫ����m
    public GameObject myprefab;
    public Vector3 spawnpoint;
    //�ͦ�����b���w��m
    void Start()
    {
        // Instantiate(instantiate1, transform.position, transform.rotation);
        //�ͦ�����b�Ӫ����m
        //Instantiate(myprefab, spawnpoint, Quaternion.identity);
        //�ͦ�����b���w��m 
        Instantiate(myprefab, spawnpoint, Quaternion.identity);
    }
    void Update()
    {
        Vector3 position = new Vector3(Random.Range(10, -10), 0, Random.Range(10, -10));
        //�H����m�ͦ�
    }

       
  
}
