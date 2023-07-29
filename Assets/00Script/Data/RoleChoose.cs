using UnityEngine;

[System.Serializable] // �ϥγo�ӥi�H�ϧA�bUnity�s�边���ݨ�o�����O�����
public partial class PlayerManager
{
    public string playerName;
    public int health;
    public int attack;
    public int recovery;

    public PlayerManager(string _name, int _health, int _attack, int _recovery)
    {
        playerName = _name;
        health = _health;
        attack = _attack;
        recovery = _recovery;
    }
}

public class RoleDataBase : MonoBehaviour
{
    // �b�C���}�l�ɪ�l�ƪ��a�C��
    public static PlayerManager[] players = new PlayerManager[]
    {
        new PlayerManager("Tank",100, 10, 3),
        new PlayerManager("Warrior",90, 12, 2),
        new PlayerManager("Assassin",70, 15, 1),
        new PlayerManager("Archer",70, 12, 1),
        new PlayerManager("Mage",70, 12, 1),
    };

    private void Start() // �C���}�l�ɳQ�I�s
    {
        // ������a��ܪ�������ޡA�w�]��0 (�Z�J)
        int selectedPlayer = PlayerPrefs.GetInt("SelectedPlayer", 0);

        // �ϥο�ܪ����ޱq���a�C����������T
        PlayerManager player = players[selectedPlayer];

        // �b����x�C�L�����T
        Debug.Log("Player: " + player.name);
        Debug.Log("Health: " + player.health);
        Debug.Log("Attack: " + player.attack);
        Debug.Log("Recovery: " + player.recovery);
    }
}