using UnityEngine;
class NPC : MonoBehaviour
{
    GameManager1 gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<player>())
        {
            gameManager.TurnOnButtom();
        }

    }
    public void TurnOnButtom()
    {
        gameManager.TurnOnButtom();
    }

}
class UI
{
    public GameObject info;//prefab
    public player player;
    public void Info()
    {

    }
}
public class drag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
class GameManager1 : MonoBehaviour
{
    GameObject buttom;
    GameObject UI;
    GameObject player;
    GameObject NPC;
    GameObject buyer;
    GameObject seller;
    public void TurnOnButtom()
    {
        buttom.SetActive(true);
    }

    [System.Obsolete]
    private void Update()
    {
        if (buttom.active == true)
        {
            if (Input.GetKey(KeyCode.B))
            {
                UI.SetActive(true);
            }
        }
    }
    void UpdateBagInfo()
    {
        for (int i = 0; i < player.GetComponent<bag>().itemsList.Count; i++)
        {

        }
    }
}
//use