using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class solt : MonoBehaviour//物件在背包
{
    public item soltitem; //物件
    public Image soltimage;//物件圖片
    public Text soltnum;//物件數量
    public string slotinfo;//資訊
    public GameObject iteminslot;//格子
    public void itemonclicked()
    {
        inventorymanager.updataiteminfo(slotinfo);
    }
    public void setupslot(item item)
    {
        if (item == null)
        {
            iteminslot.SetActive(false);
            return;
        }
        soltimage.sprite = item.itemimage;
        soltnum.text = item.itemheld.ToString();
    }
}
