using UnityEngine;

//NO
public class RoleDataBase : MonoBehaviour
{
    // 在遊戲開始時初始化玩家列表
    public static PlayerManager[] players = new PlayerManager[]
    {
        new PlayerManager("Tank",100, 10, 3),
        new PlayerManager("Warrior",90, 12, 2),
        new PlayerManager("Assassin",70, 15, 1),
        new PlayerManager("Archer",70, 12, 1),
        new PlayerManager("Mage",70, 12, 1),
    };

    private void Start() // 遊戲開始時被呼叫
    {
        // 獲取玩家選擇的角色索引，預設為0 (坦克)
        int selectedPlayer = PlayerPrefs.GetInt("SelectedPlayer", 0);

        // 使用選擇的索引從玩家列表中獲取角色資訊
        PlayerManager player = players[selectedPlayer];

        // 在控制台列印角色資訊
        Debug.Log("Player: " + player.name);
        Debug.Log("Health: " + player.health);
        Debug.Log("Attack: " + player.attack);
        Debug.Log("Recovery: " + player.recovery);
    }
}