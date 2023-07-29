using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootData
{
    public GameObject item;  // This is the item that will be dropped.
    [Range(0f, 1f)]
    public int dropChance;  // The chance that this item will be dropped (as a percentage).
}
