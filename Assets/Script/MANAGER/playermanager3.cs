using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager3 : MonoBehaviour
{
    public characterstats characterstats;
    
    public float currenthp;
    public float maxHp;
    public float healthrestore;//血量回復
    public float attack;
    public GameObject skill;
    public GameObject enemy;
    public GameObject gamemanager;

    //public GameObject popupDamage;
    //public Transform hudPos;
    public bool isdead;
    //public enum isdead{isdead}
    public float deadtime;//死亡時間
    public float time;//復活時間
    public float resurrectiontime;//復活剩餘時間
    public float timelosing_f;//計算
    public int timelosing_i;//輸出
    public float f;

    void Awake()
    {
        maxHp = 100;
        currenthp = maxHp;
        attack = 1;
        characterstats = GetComponent<characterstats>();
    }
    private void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("gamemanager");
        enemy = GameObject.FindGameObjectWithTag("enemy");
        //skill = GameObject.FindGameObjectWithTag("skill");
        time = 3;
        healthrestore = 0.01f;
    }
    void Update()
    {
        f += Time.deltaTime;
        if (Input.GetKey(KeyCode.F)&f>0.1f)//發射子彈
        {
            f = 0;
            Instantiate(skill, transform.position, transform.rotation,transform);
            //Transform bullet = Instantiate(skill.transform) as Transform;//忽略碰撞
            //Physics.IgnoreCollision(skill.GetComponent<Collider>(), transform.GetComponent<Collider>(),false);

        }
        if (Input.GetKey(KeyCode.G))
        {
            attackmyself();

        }
        if (Input.GetMouseButtonDown(0))
        {
            //GameObject mObject = (GameObject)Instantiate(popupDamage, hudPos.position, Quaternion.identity);
            //mObject.GetComponent<hudPopup>().Value = Random.Range(20, 40);
        }
        resurtime();
        Healthrestore();
        makesureHP();
    }
    public void attackmyself()
    {
        injured(attack);
    }
    public void attacksomeone()
    {
        gamemanager.GetComponent<gamemanager>().attacksomeone(gameObject, enemy);
    }
    public void injured(float attack)
    {
        currenthp -= attack;
        Debug.Log("injured");
    }
    public void makesureHP()
    {
        if (currenthp <= 0)
        {
            currenthp = 0;
            isdead = true;
        }
        else if (currenthp > maxHp)//血量不超過最大血量
        {
            currenthp = maxHp;
        }
    }
    public void resurtime()
    {

        if (isdead == true)//如果死了復活時間就會開始倒數
        {
            timelosing_f += Time.deltaTime;
            timelosing_i = Mathf.FloorToInt(timelosing_f);
            resurrectiontime = time - timelosing_f;
            if (resurrectiontime <= 0)//狀態變成活著 血量回到最大值
            {
                isdead = false;
                currenthp = maxHp;
                timelosing_f = 0;
            }
        }
    }
    public void Healthrestore()
    {
        if (isdead == false)
        {
            currenthp += healthrestore * maxHp * Time.deltaTime;//當前血量等於回復量*最大血量
        }
    }
}
