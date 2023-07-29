using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUIManager : MonoBehaviour
{

    [Header("Map")]
    public string currentMap;
    public string targetMap;
    public string[] allMap = { "Home", "City", "Field" };
    //�a��
    public GameObject World_Map;
    public Button Home, City, Field, Field2, Field3;
    public Text currentMapText;

    //���J�ؼЦa��
    public void Load_Map(string targetMap)
    {
        currentMapText.text = targetMap;
    }

}
