using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapUIManager : MonoBehaviour
{
    //�a��
    public Button Home, City, Field;
    public TextMeshProUGUI currentMapText;

    public GameObject UnitUI, UnitUIParent;

    //���J�ؼЦa��
    public void Load_Map(string targetMap)
    {
        currentMapText.text = targetMap;
    }

    public GameObject InstantiateUnitUI()
    {
        GameObject _UnitUI = Instantiate(UnitUI, UnitUIParent.transform, false);
        return _UnitUI;
    }

    public void DestroyUnitUI(GameObject UnitUI, GameObject UnitUIWorldSpace)
    {
        Destroy(UnitUI);
        Destroy(UnitUIWorldSpace);
    }
}
