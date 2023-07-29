using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
[CreateAssetMenu(fileName = "new item",menuName ="Inventory/new Item")]
public class item :ScriptableObject
{
    public string itemName;//物件名稱
    public Sprite itemimage;//物件圖片
    public int itemheld;//數量
    [TextArea]
    public string iteminfo;//資訊

    public bool equip;//消耗品or裝備
}
