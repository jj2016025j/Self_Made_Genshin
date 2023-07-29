using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager3 : MonoBehaviour
{
    public GameObject skill;
    void Start()
    {
        
    }
    public GameObject popupDamage;
    public Transform hudPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject mObject = (GameObject)Instantiate(popupDamage, hudPos.position, Quaternion.identity);
            mObject.GetComponent<hudPopup>().Value = Random.Range(20, 40);
        }

    }
}
