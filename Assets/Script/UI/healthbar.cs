using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour//幫圖片填充 血條 須配合player腳本
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private Selectable.Transition None;
    private Navigation None1;

    private void Awake()
    {
        setSlider();
    }
    public void setSlider()//設定一個slider
    {
        if (!gameObject.GetComponent<Slider>())
        {
            gameObject.AddComponent<Slider>();
        }
        slider = gameObject.GetComponent<Slider>();
        slider.transition = None;
        slider.navigation = None1;
        slider.fillRect = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
    }
    public void setmaxhealth(int health)//設定最大血量
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void sethealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
   
}
public class healthBar : MonoBehaviour 
{
    public float currentMaxHealth;
    public float currentHealth;
    public Image bar;
    public characterstats characterstats;

    void Start()
    {
        if (currentMaxHealth == 0)
        {
            currentMaxHealth = 100;
            currentHealth = currentMaxHealth;
        }
    }
    void Update()
    {
        currentMaxHealth = characterstats.currentMaxHealth;
        currentHealth = characterstats.currentHealth;

        bar.fillAmount = currentHealth / currentMaxHealth;
    }
}