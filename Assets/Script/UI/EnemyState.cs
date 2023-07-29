using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyState : MonoBehaviour {
    //宣告你需要用到的變數
    private  GameObject HP_imageGameobject;
    private GameObject HP_imageGameObjectClone;

    private Transform HP_Parent;
    private Vector3 EnemySceenPosition;

    void Start () {

        //獲取複製HP的預製體(prefab)
        HP_imageGameobject=Resources.Load<GameObject>("Enemys/Image_blod");

        //獲取放HP血條的父物體
        HP_Parent = GameObject.FindWithTag("HPPosition").transform;
        //把遊戲物體的世界座標轉換為螢幕座標
        EnemySceenPosition=Camera.main.WorldToScreenPoint(transform.position);
        //建立一個Clone血條圖片
        HP_imageGameObjectClone = Instantiate(HP_imageGameobject,EnemySceenPosition, Quaternion.identity);
        //設定血條的父物體
        HP_imageGameObjectClone.transform.SetParent(HP_Parent);
    }

    void Update () {
        //沒幀都去執行使血條跟隨物體
        PHFollowEnemy();
    }
    //血條放置到Canvas另一個Plane中 並跟隨物體移動
    void PHFollowEnemy()
    {
        //把物體座標轉換為螢幕座標，修改偏移量
        EnemySceenPosition= Camera.main.WorldToScreenPoint(transform.position)+new Vector3(0,50,0);
        HP_imageGameObjectClone.transform.position = EnemySceenPosition;
    }
}