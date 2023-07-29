using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class manager : MonoBehaviour
{
    public player player;
    public Text playerhealth;//血量
    public Text playermovespeed;//速度
    public Text playerattack;//攻擊 
    public Text totalattack;//總攻擊 
    public Text totaldamage;//總傷害
    public List<player> playerlist;//玩家列表
    /*public List<monster> monsterlist;//怪物列表
    public List<skill> skilllist;//技能數量
    public List<team> teamlist;//隊伍列表
    public List<guild> guildlist;//公會列表*/
    public List<List<List<int>>> terrain;//地形

    public void instanceterrain()
    {
        for (int i=0,j=0;i<10;i++)
        {
            for (int i1 = 0; i < 10; i++)
            {

                for (int i2 = 0; i < 10; i++)
                {
                    //terrain[i][i1][i2] = Random.Range(1, 4);
                    j = j + 1;
                }
            }
        }
    }

    public void Start()
    {
        fallconhition();
    }

    public void Update()
    {
        Debug.Log(player.position.ToString());
        playerhealth.text = "血量:" + player.nowhealth.ToString() + "/" + player.maxhealth.ToString();
        playermovespeed.text = "速度:" + player.nowmovespeed.ToString();
        playerattack.text = "攻擊:" + player.nowattack.ToString();

        if (player.nowhealth <= 0)
        {
            player.nowhealth = 0;
        }
    }
    public void attackonclick()
    {
        totalattack.text = (Int32.Parse(totalattack.text) + player.nowattack).ToString();
    }
    public void tankonclick()
    {
        player.nowhealth -= Int32.Parse(totalattack.text);
        totalattack.text = "0";
    }
    public void fallconhition()//更新數值
    {
        player.nowhealth = player.maxhealth;
        player.nowmovespeed = player.maxmovespeed;
        player.nowattack = player.maxattack;
    }
}
