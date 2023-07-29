using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;

//���J�Ϥ��ô`������
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

        //�q "ImagePlay" ��Ƨ������J�Ҧ��Ϥ�
        Object[] images = Resources.LoadAll("ImagePlay");
        Debug.Log(images);
        Debug.Log("I will try");
        foreach (var item in images)
        {
            Texture2D texture = item as Texture2D;
            sprites.Add(Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f)));
            Debug.Log("I will try");
        }

        //�]�w�Ĥ@�i�Ϥ�
        image.sprite = sprites[0];

        //�ϥέp�ɾ��Ψ�{�ӹ�{�`������
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

    //�I����
    public void OnClick()
    {
        //�W�[�I���ɨ��
        /*Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

        btn.onClick.AddListener(delegate () {
            Debug.Log("test!");
        });*/
    }

}