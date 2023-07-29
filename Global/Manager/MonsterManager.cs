using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : Organism
{
    public MapManager MapManager;

    private void Start()
    {
        MapManager.MonsterListAdd(this);
    }
    
    public void Dead()
    {
        MapManager.UnitDead(this);
        Destroy(this.gameObject);
    }
}
