using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInTheWorld : MonoBehaviour
{
    public item item;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "NPC")
        {
            other.transform.GetComponent<bag>().AddItem(item);
            Destroy(this.gameObject);
        }
    }
}
