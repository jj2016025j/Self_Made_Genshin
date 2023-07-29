using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class skillcd : MonoBehaviour
{

    Image Image;
    Text Lable;
    public string SpriteName;
    public string LableName;

    public string Q;//用來對不同的按鍵進行選擇
    // Use this for initialization
    void Start()
    {
        Image = transform.Find(SpriteName).GetComponent<Image>();//找到對應的圖片
        Lable = transform.Find(LableName).GetComponent<Text>();//找到對應的時間
    }
    bool isCude = false;
    public float TimeSpeed = 2;
    // Update is called once per frame
    void Update()
    {
        if (Q == "Q")
        {
            if (Input.GetKey(KeyCode.Q) && !isCude)
            {
                Image.fillAmount = 1;
                Lable.text = TimeSpeed.ToString("f1");
                isCude = true;
            }
        }
        if (Q == "E")
        {
            if (Input.GetKey(KeyCode.E) && !isCude)
            {
                Image.fillAmount = 1;
                Lable.text = TimeSpeed.ToString("f1");
                isCude = true;
            }
        }
        if (Q == "W")
        {
            if (Input.GetKey(KeyCode.W) && !isCude)
            {
                Image.fillAmount = 1;
                Lable.text = TimeSpeed.ToString("f1");
                isCude = true;
            }
        }
        if (Q == "R")
        {
            if (Input.GetKey(KeyCode.R) && !isCude)
            {
                Image.fillAmount = 1;
                Lable.text = TimeSpeed.ToString("f1");
                isCude = true;
            }
        }
        if (isCude)
        {
            Image.fillAmount -= (1f / TimeSpeed) * Time.deltaTime;//對圖片按照時間進行360度的旋轉剪切
            Lable.text = (TimeSpeed * Image.fillAmount).ToString("f1");//改變冷卻時間
            if (Image.fillAmount <= 0.05f)
            {
                isCude = false;
                Image.fillAmount = 0;
                Lable.text = "";
            }
        }
    }
}