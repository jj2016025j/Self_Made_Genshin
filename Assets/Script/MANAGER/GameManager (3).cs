using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    characterstats attacker;
    characterstats defener;
    internal static object Instance;
    public GameObject gameObject1;

    void Start()
    {
        gameObject1 = Instantiate(gameObject1, transform.position, Quaternion.identity);
        gameObject1.GetComponent<TPPplayermovement1>().可控制的 = false;
    }

    void Update()
    {
        
    }
    public void GetAttacker(characterstats attacker)
    {
        this.attacker = attacker;

    }
    public void GetAttack(characterstats attacker, characterstats defener)
    {
        this.attacker = attacker;
        this.defener = defener;
    }
    public void DefenerGetAttacker(characterstats defener)
    {
        if (this.attacker)
        {
            float damage = Math.Max(attacker.currentDamage * 100 / (defener.currentDefense + 100), 1);//MOBA+MMO算法
            defener.currentHealth = Math.Max(defener.currentHealth - damage, 0);
            //TODO:Upadt+e UI
            //TODO:經驗 Upadte
            defener.UpdateCharacter();
            Debug.Log("-" + damage.ToString("f0") + " " + defener.currentHealth.ToString("f0"));
            this.attacker = null;
        }
    }
}
