using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour //圖片自己填充 簡單血條系統2
{
    public float maxHealth;
    public float health;
    public Image bar;
    public characterStats characterstats;
    public GameObject _camera, Canvas;
    public Vector3 EnemySceenPosition;

    void Start()
    {
        characterstats = GetComponent<characterStats>();
        _camera = GameObject.Find("MainCamera");
        Canvas = GameObject.Find("Canvas");
        //bar= transform.GetChild(0).gameObject.GetComponent<Image>();
        //bar.transform.SetParent(Canvas.transform);
    }
    void Update()
    {
        maxHealth = characterstats.maxHealth;
        health = characterstats.health;
        bar.fillAmount = health / maxHealth;
        Canvas.transform.LookAt(_camera.transform.position + Canvas.transform.forward);

        //float dis = Vector3.Distance(transform.position, _camera.transform.position);
        //bar.transform.localScale = bar.transform.localScale;// / dis;

        //EnemySceenPosition = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, 100, 0);/// dis;
        //bar.transform.position = EnemySceenPosition;

    }

}