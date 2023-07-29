玩家腳本
using UnityEngine;

public class player : MonoBehaviour//賦予玩家血量攻擊力
{
    public int atk;
    public float currenthealth;//當前血量
    public int maxhealth;
    public float healthrestore;//血量回復
    public int id;
    public int tagteam;
    public string tag1;
    public string tag2;
    public GameObject myself;
    public GameObject skill;
    public healthbar healthbar;
    public Vector3 vector3;
    public string playerstate;
    public int deadtime;//死亡時間
    public int time;
    public int resurrectiontime;//復活剩餘時間
    private void Start()//設定基本數值
    {
        atk = 1;
        maxhealth = 100;
        currenthealth = maxhealth;//補滿血量
        healthrestore = 0.01f;
        time = 5;
        id = Random.Range(0, 100);
        tag1 = "Player";
        tag2 = "enemy";
        myself = GameObject.Find(name);//找到自己物件
        vector3 = new Vector3(0, 0, 20);//
        if (tagteam == 1)
        {
            myself.tag = tag1;
        }
        if (tagteam == 2)
        {
            myself.tag = tag2;
        }
        if (healthbar != null)//設置血量最大值 調用另一個腳本的方法
        {
            healthbar.setmaxhealth(maxhealth);
        }
        if (GameObject.Find("skill"))//找到技能物件
        {
            skill = GameObject.Find("skill");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//空白件傷害
        {
            damage((int)currenthealth, 20);
        }
        if (Input.GetKey(KeyCode.F))//發射子彈
        {
            Instantiate(skill, transform.position+ vector3, transform.rotation, transform);
        }
        if (currenthealth <= 0)
        {
            currenthealth = 0;
            if (playerstate != "dead")
            {
                Debug.Log("dead");
                deadtime = (int)Time.time;//判斷是否去世 死亡時間
            }
            playerstate = "dead";
        }
        else if (currenthealth > maxhealth)//血量不超過最大血量
        {
            currenthealth = maxhealth;
        }
        if(playerstate == "dead")//如果死了復活時間就會開始倒數
        {
            resurrectiontime = time - ((int)Time.time - deadtime);
            if (resurrectiontime <= 0)//狀態變成活著 血量回到最大值
            {
                playerstate = "life";
                currenthealth = maxhealth;
            }
        }
        if (playerstate == "life")
        {
            currenthealth += healthrestore * maxhealth * Time.deltaTime;//當前血量等於回復量*最大血量
        }
        if (healthbar != null)//血量傳給血條
        {
            healthbar.sethealth((int)currenthealth);
        }
    }
    public void damage(int originalhealth, int atk)//非靜態傷害
    {
        currenthealth -= atk;
        Debug.Log(originalhealth + "-" + atk + "=" + currenthealth);
    }
    public static void takedamage(int health, int atk)//運用空運算式 運用static 計算攻擊//防止血量過低 判斷死亡 //靜態傷害
    {
        health -= atk;
        if (health <= 0)
        {
            health = 0;
            Debug.Log("dead");
        }
        else
        {
            Debug.Log("-"+atk + "=" + health);
        }
       
    }
}

