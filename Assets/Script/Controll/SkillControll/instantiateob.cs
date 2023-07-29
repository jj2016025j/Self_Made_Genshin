using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateob : MonoBehaviour
{
    //public GameObject instantiate1;
    //生成物件在該物件位置
    public GameObject myprefab;
    public Vector3 spawnpoint;
    //生成物件在指定位置
    void Start()
    {
        // Instantiate(instantiate1, transform.position, transform.rotation);
        //生成物件在該物件位置
        //Instantiate(myprefab, spawnpoint, Quaternion.identity);
        //生成物件在指定位置 
        Instantiate(myprefab, spawnpoint, Quaternion.identity);
    }
    void Update()
    {
        Vector3 position = new Vector3(Random.Range(10, -10), 0, Random.Range(10, -10));
        //隨機位置生成
    }

       
  
}
