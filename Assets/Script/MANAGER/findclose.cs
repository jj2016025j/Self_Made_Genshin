using System.Collections.Generic;
using UnityEngine;

public class findclose : MonoBehaviour
{
    public List<GameObject> targets;
    public GameObject target;
    public void Start()
    {
        targets = new List<GameObject>( GameObject.FindGameObjectsWithTag("Player"));
    }
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            target=GetNearestGameObject(targets);
            Debug.Log("Input.GetMouseButton(0)");
        }
    }
    GameObject GetNearestGameObject(List<GameObject> listTemp)
    {
        if (listTemp != null && listTemp.Count > 0)
        {
            Debug.Log("1");
            GameObject targetTemp = listTemp.Count > 0 ? listTemp[0] : null;
            float dis = Vector3.Distance(transform.position, listTemp[0].transform.position);
            float disTemp;
            for (int i = 1; i < listTemp.Count; i++)
            {
                Debug.Log("2");
                disTemp = Vector3.Distance(transform.position, listTemp[i].transform.position);
                if (disTemp < dis)
                {
                    Debug.Log("3");
                    targetTemp = listTemp[i];
                    dis = disTemp;
                }
            }
            return targetTemp;
        }
        else
        {
            return null;
        }
    }
}
