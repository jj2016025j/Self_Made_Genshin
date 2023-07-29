using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag : MonoBehaviour//應該可以不用mono
{
    public List<item> itemsList;
    public void AddItem(item item)
    {
        item.itemAmount++;
        if (itemsList.Contains(item))
        {
            return;
        }
        itemsList.Add(item);
    }
    public void RemoveItem(item item)
    {
            item.itemAmount--;
        if (item.itemAmount <= 0)
        {
            itemsList.Remove(item);
            item.itemAmount=0;
            return;
        }
    }
}
