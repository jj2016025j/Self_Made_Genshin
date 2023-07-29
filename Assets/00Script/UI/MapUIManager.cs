using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Not yet
public class MapUIManager : MonoBehaviour
{
    //地圖
    public Button Home, City, Field;
    public TextMeshProUGUI currentMapText;

    //載入目標地圖
    public void Load_Map(string targetMap)
    {
        currentMapText.text = targetMap;
    }
}
