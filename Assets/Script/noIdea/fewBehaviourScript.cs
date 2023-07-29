using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour//技能
{
    //要補護盾!!!!!!!!!
    //buff
    public trigger healing;//補血

    //nerf
    
    public string[] skilltype;//技能種類

    public player[] playerA;//輸出者
    public player[] playerB;//被輸出者
    public GameObject player;  

    void Start()
    {
        skilltype[]= (buff[], nerf[], physics[], other[]);

        buff[]= (HP, ATK, MAG, SPD);
        nerf[]= (HP, ATK, MAG, SPD);
        physics[]= ();
        other[]= ();

        playerA[] = GameObject.Find("playerA");//尋找物件
        playerB[] = GameObject.Find("playerB");
        var findObjects = FindObjectOfType<enemy>();//尋找有組件的項目
        Debug.Log("組件數量" + findObjects.Length);//尋找到的數量

        
    }


    void FixedUpdate()
    {

    }
    Instantiate(物件, 位置, 轉動)
    void OntriggerEnter(collider other)
    {
        switch (skilltype[])//技能種類
        {
            case == buff[]:
                switch (buff[0])
                {
                    case == HP:
                        basicATK()
                        break;
                }           
                
            case == nerf[]:
                switch (nerf[0])
                {
                    case == HP:
                        healing()
                        break;
                }
                break;
        }

    void OntriggerExit(collider other)
    {

    }

    void OntriggerStay(collider other)
    {

    }

    void basicatk()//基礎攻擊
        {
        PlayerB.HP = PlayerB.HP - playerA.ATK;
        Debug.Log("對" + PlayerB + "造成" + playerA.ATK + "傷害");
    }
    void skillatk()//技能傷害
    {
        PlayerB.HP = PlayerB.HP - playerA.ATK * 1.2f;
        Debug.Log("造成傷害*" + playerA.ATK * 1.2f);
    }
    void healing()//治癒
    {
        PlayerB.HP = PlayerB.HP + playerA.mag;
        Debug.Log("回復生命*"+ playerA.mag);
    }
    void slowmove()//緩速
    {
        PlayerB.mspd = PlayerB.mspd *0.5f;
        Debug.Log("緩速");
    }
    void daze()//暈眩
    {
        PlayerB.mspd = 0;速度為零
        Debug.Log("暈眩");
    }
    void daze()//抵銷
    {
        Destroy(gameObject,0);//X秒後刪除物件
        Debug.Log("抵銷物件");
    }
    void daze()//反射
    {
        journeyLength = Vector.Distance(startMarker.position, endMarker.position);//開啟物件重力並施加某方向的力
        transform.LookAt(endMarker);//轉向目標
        float discovered = (Time.time - startTime) * speed;//移動時間*速度
        float fracjourney = discovered / journeyLength;//現在比例位置=現在長度/總長
        transform.position=Vector3.Lerp(startMarker.position, endMarker.position, fracjourney)//滑順的移動到終點

    }

        void skillstay()//持續效果
        Invoke("FixedUpdate", 2);
        //這個比較簡單，寫在c#腳本中，意為 兩秒之后調用一次，MethodName方法。
        InvokeRepeating("FixedUpdate", 1, 2);
        //這個方法就是多次調用Invoke，即理解為一秒后，每隔兩秒調用MethodName方法。
        CancelInvoke("FixedUpdate");
        //取消MethodName方法的調用。
    }

