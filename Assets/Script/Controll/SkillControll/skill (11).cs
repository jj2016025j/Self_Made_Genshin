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
        if ((collision.gameObject.tag == "Player"||collision.gameObject.tag == "enemy")&& collision.gameObject.GetComponent<player>() )//取得碰撞單位 判斷是TAG 且有玩家(player)腳本
        {
            player.takedamage((int)collision.gameObject.GetComponent<player>().currenthealth, parent.GetComponent<player>().atk);//呼叫攻擊
            collision.gameObject.GetComponent<player>().currenthealth -= parent.GetComponent<player>().atk;//被攻擊者-攻擊者傷害 下面是另一個攻擊函數 因為靜態問題還沒處理好
            if (collision.gameObject.GetComponent<player>().currenthealth <= 0)
            {
                collision.gameObject.GetComponent<player>().currenthealth = 0;
                Debug.Log("dead");
            }
            Destroy(gameObject, 3);
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}