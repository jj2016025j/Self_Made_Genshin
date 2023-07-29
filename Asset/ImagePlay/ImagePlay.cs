using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;

//載入圖片並循環撥放
public class ImagePlay : MonoBehaviour
{
    public Image image;
    public List<Sprite> sprites;
    public int currentImageIndex;
    public GameObject UICanvas;

    void Start()
    {
        DontDestroyOnLoad(UICanvas);

        sprites = new List<Sprite>();

        //從 "ImagePlay" 資料夾中載入所有圖片
        Object[] images = Resources.LoadAll("ImagePlay");
        Debug.Log(images);
        Debug.Log("I will try");
        foreach (var item in images)
        {
            Texture2D texture = item as Texture2D;
            sprites.Add(Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f)));
            Debug.Log("I will try");
        }

        //設定第一張圖片
        image.sprite = sprites[0];

        //使用計時器或協程來實現循環播放
        StartCoroutine(PlayImages());
    }

    IEnumerator PlayImages()
    {
        while (true)
        {
            currentImageIndex = (currentImageIndex + 1) % sprites.Count;
            image.sprite = sprites[currentImageIndex];
            yield return new WaitForSeconds(5);
        }
    }

    //點擊時
    public void OnClick()
    {
        //增加點擊時函數
        /*Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

        btn.onClick.AddListener(delegate () {
            Debug.Log("test!");
        });*/
    }

}