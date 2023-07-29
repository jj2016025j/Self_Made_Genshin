using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventorymanager : MonoBehaviour
{
    static inventorymanager instance; //這個腳本
    public inventory mybag; //倉庫
    public GameObject slotgrid; //背包格子
    //public solt soltprefab;//格子
    public GameObject emptyslot;
    public Text iteminfomation;//物件資訊
    public List<GameObject> slots = new List<GameObject>();
    void Awake ()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    private void OnEnable()
    {
        reflashitem();
        instance.iteminfomation.text = "";
    }
    public static void updataiteminfo(string itemdescription)
    {
        instance.iteminfomation.text = itemdescription;
    }
    public static void reflashitem()
    {
        for (int i = 0; i < instance.slotgrid.transform.childCount; i++)
        {
            if (instance.slotgrid.transform.childCount == 0)
                break;
            Destroy(instance.slotgrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
        for (int i = 0; i < instance.mybag.itemList.Count; i++)
        {
            instance.slots.Add(Instantiate(instance.emptyslot));
            instance.slots[i].transform.SetParent(instance.slotgrid.transform);
            instance.slots[i].GetComponent<solt>().setupslot(instance.mybag.itemList[i]);
        }
    }
}
