using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public enum ItemName
    {
        A,B,C,D,E
    }
    public string itemName;
    public Sprite itemImage;
    public int itemID;
    public int itemAmount;//count,quantity
    [TextArea] //���ܿ�J�خ榡�A���ܿ�J�خe�q
    public string info;
    //switch
}