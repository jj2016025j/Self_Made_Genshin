using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    public GameObject skillbuttom;
    public GameObject skill;
    public GameObject windows;
    public Button button; 
    public Image skillImage;
    public Text skillText;
    //public Event keycode;
    public float skillTimeSpeed;
    public bool skillIstiming;
    public bool isopen;
    public ButtonType buttonType;
    public enum ButtonType
    {
        SWITCH,
        ACTION,
        SKILL
    }
    
    void Start()
    {
        skillImage.fillAmount = 1;
        skillTimeSpeed = 1f;
        skillIstiming = false;
        isopen = false;
        button.onClick.AddListener(() => action());// 獲得技能按鈕，然后绑定點擊事件
        //keycode.keyCode = KeyCode.B;
    }
    private void FixedUpdate()
    {
        switch (buttonType)
        {
            case ButtonType.SWITCH:
                if (Input.GetKeyDown(KeyCode.B))
                {
                    openwindows();
                }
                break;

            case ButtonType.ACTION:
                if (Input.GetKey(KeyCode.B))
                {
                    action();
                }
                break;

            case ButtonType.SKILL:
                if (Input.GetKey(KeyCode.B))
                {
                    Skill();
                }
                if (skillIstiming)
                {
                    skillImage.fillAmount -= (1f / skillTimeSpeed) * Time.deltaTime;//對圖片按照時間進行360度的旋轉剪切
                    skillText.text = (skillTimeSpeed * skillImage.fillAmount).ToString("f1");//改變冷卻時間
                    if (skillImage.fillAmount <= 0f)
                    {
                        skillIstiming = false;
                        skillImage.fillAmount = 1;
                        skillText.text = "";
                    }
                }
                break;
        }

        
    }
    public void openwindows()
    {
        isopen = !isopen;
        windows.SetActive(isopen);
    }
    public void action()
    {
        Debug.Log("action");
    }
    public void Skill()
    {
        if (skillImage.fillAmount == 1)
        {
            Instantiate(skill, transform);
            skillImage.fillAmount = 1f;
            skillText.text = skillTimeSpeed.ToString("f1");
            skillIstiming = true;
        }
    }
    
}
