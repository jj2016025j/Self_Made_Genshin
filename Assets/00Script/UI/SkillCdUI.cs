using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SocialPlatforms;

//還沒拉進去
public class SkillCdUI : MonoBehaviour
{
    public Image Image;
    public TextMeshProUGUI time;

    public bool SkillEnable = true;
    public float CDTime = 0.1f;

    private void Start()
    {
        time.gameObject.SetActive(false);
        Image.gameObject.SetActive(false);
        Image.fillAmount = 1;
    }
    void Update()
    {
        if (!SkillEnable)
        {
            //
            time.gameObject.SetActive(true);
            Image.gameObject.SetActive(true);

            Image.fillAmount -= (1f / CDTime) * Time.deltaTime;//對圖片按照時間進行360度的旋轉剪切
            time.text = (CDTime * Image.fillAmount).ToString("f1");//改變冷卻時間

            if (Image.fillAmount <= 0.05f)
            {
                SkillEnable = true;
                time.gameObject.SetActive(false);
                Image.gameObject.SetActive(false);
                Image.fillAmount = 1;
                time.text = "";
            }
        }
    }
}