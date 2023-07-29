using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public List<GameObject> player;
    public List<GameObject> monster;
    public List<GameObject> skill;
    public float time;
    void Start()
    {
        player = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        monster = new List<GameObject>(GameObject.FindGameObjectsWithTag("monster"));
        skill = new List<GameObject>(GameObject.FindGameObjectsWithTag("skill"));
        time = 60;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            player = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
            monster = new List<GameObject>(GameObject.FindGameObjectsWithTag("monster"));
            skill = new List<GameObject>(GameObject.FindGameObjectsWithTag("skill"));
            time = 60;
        }
    }
    public static void attacksomeone(float attack, GameObject passive)
    {
        //passive.GetComponent<playermanager>().attackbysomeone(attack);
    }
    void healsomeone()
    {

    }
}
