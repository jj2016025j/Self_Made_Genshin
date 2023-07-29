using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(fileName = "new worlditem", menuName = "World/new worlditem")]
public class worlditem : ScriptableObject
{
    public string itemName;//物件名稱
    public Sprite itemimage;//物件圖片
    public int itemheld;//數量
    [TextArea]
    public string iteminfo;//資訊

    public bool equip;//消耗品or裝備
}
