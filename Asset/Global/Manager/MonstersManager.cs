using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonstersManager : MonoBehaviour
{
    public MapManager MapManager;
    public List<Monster> Monsters;

    public void Start()
    {
        MapManager = MapManager == null ? GameObject.Find("MapUI").GetComponent<MapManager>() : MapManager;
    }
    public void RemoveThisMonster(Monster Monster)
    {
        Monsters.Remove(Monster);
    }
}
