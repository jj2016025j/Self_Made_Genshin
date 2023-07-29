using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour //圖片自己填充 簡單血條系統2
{
    public float maxHP;
    public float HP;
    public Image bar;
    public player player;

    void Start()
    {
        maxHP = GetComponent<health>().maxHP;
        HP = GetComponent<health>().HP;
        if (!GetComponent<Image>())//如果找不到圖片
        {
            getimage();
        }
        bar = GetComponent<Image>();
        if (maxHP == 0)
        {
            maxHP = 100;
            HP = maxHP;
        }
        if (gameObject.transform.parent.transform.parent.transform.parent.GetComponent<player>())//找到玩家腳本
        {
            player = gameObject.transform.parent.transform.parent.transform.parent.GetComponent<player>();
        }
        //player.ade(maxHP, HP);
    }

    // Update is called once per frame
    void Update()
    {
        if (player)//抓玩家的血量
        {
            maxHP = player.maxhealth;
            HP = player.currenthealth;
        }
        bar.fillAmount = HP / maxHP;//輸出到血條上
    }
    void getimage()
    {

    }
}
/*public class health : MonoBehaviour //簡單血條系統 移動血條位置
{
    public float maxHP;
    public float HP;
    public float width;//血條長度
    public RectTransform anchors;//錨點

    void Start()
    {
        maxHP = GetComponent<health>().maxHP;
        HP = GetComponent<health>().HP;
        width = 100;
        if (this.GetComponent<RectTransform>())//width = anchors.Width;//如果找的到的話
        {
            
            }
        if (gameObject.transform.parent.GetComponent<player>())
        {
            maxHP = gameObject.transform.parent.GetComponent<player>().maxhealth;
            HP = gameObject.transform.parent.GetComponent<player>().currenthealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(-width + width * HP/maxHP, 0,0);
    }
}*/