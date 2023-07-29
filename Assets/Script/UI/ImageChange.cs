using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public List<Sprite> images1 = new List<Sprite>();
    public List<Sprite> images2 = new List<Sprite>();
    public int index1;
    public int index2;

    void Start()
    {
        image1.sprite = images1[index1];
        index1++;
        image2.sprite = images2[index2];
        index2++;
        StartCoroutine(MyCoroutine());
        //InvokeRepeating("GetKeyDownAndcycleImage", 0, 1); // 0 ���}�l�A�C 1 �����@�� GetKeyDown And cycle Image()
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GetKeyDown And cycle Image
            if (index1 >= images1.Count)
            {
                index1 = 0;
                image1.sprite = images1[index1];
                return;
            }
            image1.sprite = images1[index1];
            index1++;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //GetKeyDown And cycle Image
            if (index2 >= images2.Count)
            {
                index2 = 0;
                image2.sprite = images2[index2];
                return;
            }
            image2.sprite = images2[index2];
            index2++;
        }
    }
    IEnumerator MyCoroutine()
    {
        while (true)
        {
            // �n���檺���O
            if (index2 >= images2.Count)
            {
                index2 = 0;
                image2.sprite = images2[index2];
                yield return new WaitForSeconds(2);
            }
            image2.sprite = images2[index2];
            index2++;

            Debug.Log("MyCoroutine is called!");
            yield return new WaitForSeconds(2);
        }
    }

    void GetKeyDownAndcycleImage()
    {
        // �n���檺���O
        //GetKeyDown And cycle Image
        if (index1 >= images1.Count)
        {
            index1 = 0;
            image1.sprite = images1[index1];
            return;
        }
        image1.sprite = images1[index1];
        index1++;
        Debug.Log("MyFunction is called!");
    }
}
