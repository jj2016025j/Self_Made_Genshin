using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : Organism
{
    public MapManager mapManager;
    public PlayerUIManager PlayerUIManager;

    private void Start()
    {
        mapManager=GameObject.Find("GameManager").GetComponent<MapManager>();
        PlayerUIManager = GameObject.Find("GameManager").GetComponent<PlayerUIManager>();
        mapManager.MonsterListAdd(this);
    }
    
    public void Dead()
    {
        mapManager.UnitDead(this);
        Destroy(this.gameObject);
    }
}
