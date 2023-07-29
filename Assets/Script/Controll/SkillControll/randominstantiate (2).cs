using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randominstantiate : MonoBehaviour
{
    [SerializeField] GameObject[] floorarray;
    [SerializeField] float countdowntime;
    void Start()
    {
        // transform.parent=GameObject.Find("GameObject").transform;
        countdowntime = 2;
    }
    void FixedUpdate()
    {
        countdowntime -= Time.deltaTime;
        if (countdowntime <= 0)
        {
            countdowntime = Random.Range(0f, 2f);
            Debug.Log("計時結束");
            floorspawn();
        }
    }
    [SerializeField]public void floorspawn()
    {
        int r = Random.Range(0, floorarray.Length);
        GameObject floor=Instantiate(floorarray[r], transform);
        floor.transform.position = new Vector3(Random.Range(-10, 10), -10, 0); //Random.Range(-5, 5)
    }
}
