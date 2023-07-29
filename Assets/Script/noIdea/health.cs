using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour //圖片自己填充 簡單血條系統2
{
    public float maxHP;
    public float HP;
    public Image bar;
    public GameObject player;
    public playermanager3 playermanager;
    public Text hptext;

    void Start()
    {
        if (maxHP == 0)
        {
            maxHP = 100;
            HP = maxHP;
        }
        bar = GetComponent<Image>();
        playermanager = player.GetComponent<playermanager3>();
    }
    void Update()
    {
        maxHP = playermanager.maxHp;
        HP = playermanager.hp;
        
        hptext.text = HP.ToString("f0") +"/"+ maxHP.ToString("f0");
        bar.fillAmount = HP / maxHP;//輸出到血條上
    }
}