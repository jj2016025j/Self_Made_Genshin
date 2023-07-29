using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour //圖片自己填充 簡單血條系統2
{
    public float maxHP;
    public float currentHP;
    public Image bar;
    public GameObject player;
    public playermanager3 playermanager;
    public Text hptext;//gamemanagermanager

    void Start()
    {
        if (maxHP == 0)
        {
            maxHP = 100;
            currentHP = maxHP;
        }
        bar = GetComponent<Image>();
        if(transform.parent.gameObject.GetComponent<playermanager3>())
        player = transform.parent.gameObject;
        if(transform.parent.parent.gameObject.GetComponent<playermanager3>())
        player = transform.parent.parent.gameObject;
        playermanager = player.GetComponent<playermanager3>();
        hptext = transform.GetChild(0).gameObject.GetComponent<Text>();
    }
    void Update()
    {
        maxHP = playermanager.maxHp;
        currentHP = playermanager.currenthp;
        
        hptext.text = currentHP.ToString("f0") +"/"+ maxHP.ToString("f0");
        bar.fillAmount = currentHP / maxHP;//輸出到血條上
    }
}