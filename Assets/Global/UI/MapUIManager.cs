using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapUIManager : MonoBehaviour
{

    [Header("Map")]
    public string[] allMap = { "Home", "City", "Field" };
    //�a��
    public Button Home, City, Field;
    public TextMeshProUGUI currentMapText;

    public GameObject UnitUI, UnitUIParent;

    //���J�ؼЦa��
    public void Load_Map(string targetMap)
    {
        currentMapText.text = targetMap;
    }

    private void InstantiateUnitUI()
    {
        Instantiate(UnitUI, UnitUIParent.transform, false);
    }
}
