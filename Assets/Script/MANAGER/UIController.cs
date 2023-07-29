using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenCloseUI(){
        switch (UIController.UIcode)
            {
                case UIcode.Map:
                    UIController=MapUI;
                    MapUI_Object.setactive=!MapUI_Object.setactive;
                    break;
                case UIcode.MapUnitUpdate:
                    break;
                default:
                    Debug.Log("輸入錯誤");
                    break;
            }
    }
    public UI MapUI;
    public UI MapUnitUpdateUI;
    public UI SettingUI;
    public UI BagUI;
    public UI BattlePlayerOrUnitUI;
    public UI UIController;
    public GameObject MapUI_Object;
}
public class UI{
    public enum UIcode{
        Map=0,
        MapUnitUpdate=1,
        Setting=2,
        Bag=3,
        BattlePlayerUnit=4
    } 
}

    ///確定每個參數都有抓到
