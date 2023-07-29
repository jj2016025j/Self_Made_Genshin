using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class playerui2 : MonoBehaviour
{
    public GameObject flyskillbuttom;
    public GameObject flyskill;
    public Image flyskillImage;
    public Text flyskillText;
    public float flyskillTimeSpeed;
    public bool flyskillIstiming;

    public GameObject slashskill; 
    public GameObject slashskillbuttom;
    public Image slashskillImage;
    public Text slashskillText;
    public float slashskillTimeSpeed;
    public bool slashskillIstiming;

    public Button jumpbuttom;

    public GameObject movebuttom;//

    public GameObject bagbuttom;
    public GameObject bag;
    public bool bagisopen;

    public Button inspectorbuttom;
    public GameObject inspector;
    public bool inspectorisopen;


    private void Start()
    {
        flyskillImage.fillAmount = 1;
        flyskillTimeSpeed = 1f;
        slashskillImage.fillAmount = 1;
        slashskillTimeSpeed = 1f;
        slashskillIstiming = false;
        flyskillIstiming = false;
        bagisopen = false;
        jumpbuttom.onClick.AddListener(() => jump());// 獲得技能按鈕，然后绑定點擊事件
        inspectorbuttom.onClick.AddListener(() => openinspector());
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Slashskill();
        }
        if (slashskillIstiming)
        {
            slashskillImage.fillAmount -= (1f / slashskillTimeSpeed) * Time.deltaTime;//對圖片按照時間進行360度的旋轉剪切
            slashskillText.text = (slashskillTimeSpeed * slashskillImage.fillAmount).ToString("f1");//改變冷卻時間
            if (slashskillImage.fillAmount <= 0f)
            {
                slashskillIstiming = false;
                slashskillImage.fillAmount = 1;
                slashskillText.text = "";
            }
        }
        if (Input.GetMouseButton(1))
        {
            Flyskill();
        }
        if (flyskillIstiming)
        {
            flyskillImage.fillAmount -= (1f / flyskillTimeSpeed) * Time.deltaTime;//對圖片按照時間進行360度的旋轉剪切
            flyskillText.text = (flyskillTimeSpeed * flyskillImage.fillAmount).ToString("f1");//改變冷卻時間
            if (flyskillImage.fillAmount <= 0f)
            {
                flyskillIstiming = false;
                flyskillImage.fillAmount = 1;
                flyskillText.text = "";
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            jump();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            openbag();
        }

        
    }
    public void Flyskill()
    {
        if (flyskillImage.fillAmount == 1)
        {
            Instantiate(flyskill, transform);
            flyskillImage.fillAmount = 1f;
            flyskillText.text = slashskillTimeSpeed.ToString("f1");
            flyskillIstiming = true;
        }
    }
    public void Slashskill()
    {
        if (slashskillImage.fillAmount == 1)
        {
            Instantiate(slashskill, transform);
            slashskillImage.fillAmount = 1f;
            slashskillText.text = slashskillTimeSpeed.ToString("f1");
            slashskillIstiming = true;
        }
    }
    public void openbag()
    {
        bagisopen = !bagisopen;
        bag.SetActive(bagisopen);
    }
    public void jump()
    {
        Debug.Log("i jump");
    }
    public void openinspector()//資訊
    {
        inspectorisopen = !inspectorisopen;
        inspector.SetActive(inspectorisopen);
    }
}
