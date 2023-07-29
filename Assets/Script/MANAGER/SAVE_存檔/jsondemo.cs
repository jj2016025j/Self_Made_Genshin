using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class jsondemo : MonoBehaviour
{
    void Start()
    {

        //宣告一個Listy作為道具列表並存入兩個道具
        List<string> equips = new List<string>();
        equips.Add("sword");
        equips.Add("shield");
        equips.Add("apple");

        //用剛剛宣告好的Class創建一個儲存數值的物件，並給予數值欄位對應的數值(例如生命設定為100，金錢250....)

        Data newData = new Data
        {
            health = 200,
            money = 2500,
            equip = equips
        };

        //把剛剛創建好的數值物件轉為Json字串，並用JsonInfo參數儲存，接下來把這個字串寫入指定的檔案位置(下面紅色字請改成自己的路徑《都可以》最後面是檔案名稱)

        string jsonInfo = JsonUtility.ToJson(newData, true);
        File.WriteAllText("D:/本來在C槽/unity練習專案/test01/Assets/file1", jsonInfo);

        Debug.Log("寫入完成");
    }

}

//要儲存的資料用一個Class去儲存，裡面可以放各類型的資料(但是不能放Dictionary 很重要!!!我被呼弄很久)
public class Data
{
    public float health;
    public int money;
    public List<string> equip;
}