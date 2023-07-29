using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour//血條 須配合player腳本
{
    public Slider slider;
     private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();//滑桿
    }
    public Gradient gradient;//調整顏色的腳本
    public Image fill;//顏色圖案
    public void setmaxhealth(int health)//血條控制
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void sethealth(int health)//血條控制
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
   
}
