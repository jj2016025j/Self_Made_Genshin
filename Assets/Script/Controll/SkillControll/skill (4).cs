using UnityEngine;

public class skill : MonoBehaviour//技能觸發
{
    public GameObject parent;
    public GameObject child;
    public player player;
    public int childcount;
    public float speed = 100;
    public healthbar healthbar;
    private void Start()
    {
        if (gameObject.transform.parent.gameObject==true)
        {
            parent = gameObject.transform.parent.gameObject;//取得父物件
            player = parent.GetComponent<player>();
            gameObject.transform.parent = null;
        }
        Destroy(gameObject, 10);
        speed = 100;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Player"||collision.gameObject.tag == "enemy")&& collision.gameObject.GetComponent<player>() )//取得碰撞單位 判斷是敵人 且有玩家(player)腳本
        {
            player.takedamage((int)collision.gameObject.GetComponent<player>().currenthealth, parent.GetComponent<player>().atk);
            collision.gameObject.GetComponent<player>().currenthealth -= parent.GetComponent<player>().atk;
            if (collision.gameObject.GetComponent<player>().currenthealth <= 0)
            {
                collision.gameObject.GetComponent<player>().currenthealth = 0;
                Debug.Log("dead");
            }
            Destroy(gameObject, 3);
        }
    }
    public void parentvoid(GameObject parent, GameObject child, int childcount,GameObject nobody)
    {
        parent=gameObject.transform.parent.gameObject;//取得父物件
        child = gameObject.transform.GetChild(0).gameObject;//取得子物件
        childcount = gameObject.transform.childCount;//取得子物件數量
        nobody.transform.parent = gameObject.transform;//前者子後者父
        gameObject.transform.parent = nobody.transform;//前者父後者子
        gameObject.transform.parent = null;//脫離父物件
    }//目前不用
    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}