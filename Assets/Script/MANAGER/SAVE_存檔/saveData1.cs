using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class saveData1 : MonoBehaviour
{
    [SerializeField]
    Text ui;
    Text ui1;
    [SerializeField]
    Playerdata data;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            FileStream fs = new FileStream(Application.dataPath + "/Save.txt", FileMode.Create);//新檔案名稱"",建立
            StreamWriter sw = new StreamWriter(fs);//寫入功能sw
            sw.WriteLine(data.name);//寫入
            sw.WriteLine(data.level);
            sw.Close();//關閉
            fs.Close();
            ui.text = "儲存成功";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            FileStream fs = new FileStream(Application.dataPath + "/Save.txt", FileMode.Open);//檔案名稱"",打開
            StreamReader sr = new StreamReader(fs);//閱讀功能sr
            data.name = sr.ReadLine();//閱讀後丟入
            data.level = int.Parse(sr.ReadLine());
            ui.text = "讀取";
        }
    }
}
/*[System.Serializable]
public class Playerdata
{
    public string name;
    public int level;
}*/