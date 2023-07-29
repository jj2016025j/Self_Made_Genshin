using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
public class saveData4 : MonoBehaviour//Binary
{
    [SerializeField]
    Text ui;
    Text ui1;
    [SerializeField]
    Playerdata data;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetString("jsondata", JsonUtility.ToJson(data));
            ui.text = "儲存成功";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            data = JsonUtility.FromJson<Playerdata>(PlayerPrefs.GetString("json"));
            ui.text = "讀取";
        }
    }
}
[System.Serializable]
public class Playerdata
{
    public string name;
    public int level;
}