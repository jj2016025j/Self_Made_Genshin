using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class saveData2 : MonoBehaviour//Binary
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
            BinaryFormatter bf = new BinaryFormatter();
            Stream s = File.Open(Application.dataPath + "/Save.txt", FileMode.Create);
            bf.Serialize(s, data);
            s.Close();
            ui.text = "儲存成功";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            BinaryFormatter bf = new BinaryFormatter();
            Stream s = File.Open(Application.dataPath + "/Save.txt", FileMode.Open);
            data = (Playerdata)bf.Deserialize(s);
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