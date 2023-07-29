using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootData
{
    public GameObject item;  // This is the item that will be dropped.
    public int dropChance;  // The chance that this item will be dropped (as a percentage).
}
