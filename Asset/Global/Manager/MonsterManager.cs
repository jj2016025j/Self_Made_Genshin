using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    public PlayerControllerUIManager PlayerUIManager;

    public Monster Monster;
    public MonstersManager MonstersManager;
    public NavMeshAgent AIControll;

    public PlayerManager PlayerManager;
    //public Organism Target;


    public void Start()
    {
        PlayerManager = PlayerManager == null ? GameObject.Find("PlayerManager").GetComponent<PlayerManager>() : PlayerManager;
    }

    public void IfDead(Monster Monster)
    {
        MonstersManager.RemoveThisMonster(Monster);
    }
}
