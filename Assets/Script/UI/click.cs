using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click : MonoBehaviour
{
    public GameObject fooddelivery,loadui;//找gameobject
    public CanvasGroup fooddeliverycanvasgroup;//找canvasgroup元件


    void Start()
    {
        if (GameObject.Find("fooddelivery").GetComponent<CanvasGroup>())
        {
            fooddeliverycanvasgroup = GameObject.Find("fooddelivery").GetComponent<CanvasGroup>();
            fooddeliverycanvasgroup.alpha = 1;//canvasgroup元件隱藏
        }
        if (GameObject.Find("fooddelivery"))
        {
            fooddelivery = GameObject.Find("fooddelivery");
            fooddelivery.active = false;//關閉fooddelivery
        }
        if (GameObject.Find("loadui"))
        {
            loadui = GameObject.Find("loadui");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openUI()
    {
        if (fooddelivery.active == false)
        {
            fooddelivery.active = true;//開啟fooddelivery
        }
    }
    public void clossUI()
    {
        if (fooddelivery.active == true)
        {
            fooddelivery.active = false;//關閉fooddelivery
        }
    }
    public void clossloadUI()
    {
        loadui.active = false;
    }
}
//public CanvasGroup fooddelivery;
/*fooddelivery = GameObject.Find("fooddelivery").GetComponent<CanvasGroup>();
       fooddelivery.alpha = 0;
       fooddelivery.interactable = false;*/
/*fooddelivery.alpha = 1;
    fooddelivery.interactable = true;*/
/*fooddelivery.alpha = 0;
    fooddelivery.interactable = false;*/