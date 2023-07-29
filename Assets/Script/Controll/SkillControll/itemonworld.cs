using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemonworld : MonoBehaviour //在世界中物件
{
    public item thisitem;//此物件
    public inventory playerinventory; //玩家庫存
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            addnewitem();
            Destroy(gameObject);
        }
    }
    void addnewitem()
    {
        if(!playerinventory.itemList.Contains(thisitem))
        {
            for (int i = 0; i < playerinventory.itemList.Count; i++)
            {
                if (playerinventory.itemList[i] == null)
                {
                    playerinventory.itemList[i] = thisitem;
                    break;
                }
            }
        }
        thisitem.itemheld++;//數量+1
        inventorymanager.reflashitem();
    }
}
