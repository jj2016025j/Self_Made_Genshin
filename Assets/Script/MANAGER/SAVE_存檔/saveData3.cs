using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
public class saveData3 : MonoBehaviour//Binary
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
            XmlSerializer xml = new XmlSerializer(data.GetType());
            Stream s = File.Open(Application.dataPath + "/Save.xml", FileMode.Create);
            xml.Serialize(s, data);
            s.Close();
            ui.text = "儲存成功";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            XmlSerializer xml = new XmlSerializer(data.GetType());
            Stream s = File.Open(Application.dataPath + "/Save.xml", FileMode.Open);
            data = (Playerdata)xml.Deserialize(s);
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