using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveData : MonoBehaviour
{
    [SerializeField]
    Text ui;
    [SerializeField]
    Playerdata data;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetString("name", data.name);//在櫃子"name"裡的空間放入data.name的變數
            PlayerPrefs.SetInt("level", data.level);
            ui.text = "儲存成功";
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            data.name = PlayerPrefs.GetString("name");//讀取櫃子名稱"name"內的變數
            data.level = PlayerPrefs.GetInt("level");
            ui.text = "讀取成功";
        }
    }
}
/*[System.Serializable]
public class Playerdata
{
    public string name;
    public int level;
}*/