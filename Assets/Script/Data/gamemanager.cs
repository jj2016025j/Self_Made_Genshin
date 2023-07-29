using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public List<GameObject> players;
    public List<GameObject> monsters;
    //public List<GameObject> skill;
    public GameObject player;
    public GameObject monster;
    public GameObject enemy;
    public float time;
    void Start()
    {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        monsters = new List<GameObject>(GameObject.FindGameObjectsWithTag("monster"));
        time = 60;
        player=null;
        monster = null;
        enemy = null;
}

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            
            time = 60;
        }
    }
    public void attacksomeone(GameObject player, GameObject monster)//收到攻擊信息並傳給被攻擊者
    {
        float attack = player.GetComponent<playermanager3>().attack;
        monster.GetComponent<playermanager3>().injured(attack);
    }
    void healsomeone()
    {

    }
}
