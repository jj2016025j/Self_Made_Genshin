using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class jsonload : MonoBehaviour
{

    //宣告一個字串讀取檔案，宣告一個Data物件(上一篇定義的可用來存放遊戲資訊)來取得字串轉換後的物件
    string LoadData;
    Data MyData;
    void Start()
    {

        //讀取指定路徑的Json檔案並轉成字串(路徑同上一篇)
        LoadData = File.ReadAllText("D:/本來在C槽/unity練習專案/test01/Assets/"+"file1");

        //把字串轉換成Data物件
        MyData = JsonUtility.FromJson<Data>(LoadData);

        //印出物件中的數值
        Debug.Log("玩家生命為 " + MyData.health);
        Debug.Log("玩家金錢為 " + MyData.money);
        Debug.Log("玩家有" + MyData.equip.Count + "個裝備");
    }
}