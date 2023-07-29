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
    //地圖
    public GameObject World_Map;
    public Button Home, City, Field, Field2, Field3;
    public Text currentMapText;

    //載入目標地圖
    public void Load_Map(string targetMap)
    {
        currentMapText.text = targetMap;
    }

}
