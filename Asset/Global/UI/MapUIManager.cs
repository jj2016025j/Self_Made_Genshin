using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Not yet
public class MapUIManager : MonoBehaviour
{
    //�a��
    public Button Home, City, Field;
    public TextMeshProUGUI currentMapText;

    //���J�ؼЦa��
    public void Load_Map(string targetMap)
    {
        currentMapText.text = targetMap;
    }
}
