using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager3 : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public float attack;
    public GameObject enemy;
    void Awake()
    {
        maxHp = 100;
        hp = maxHp;
        attack = 10;
    }

    void Update()
    {
        if (hp >= maxHp)
            hp = maxHp;
        if (hp <= 0)
            hp = 0;
    }
    public void attacksomeone()
    {
        manager.attacksomeone(attack, enemy);
    }
    public static void attackbysomeone(float attack)
    {
    }
}
