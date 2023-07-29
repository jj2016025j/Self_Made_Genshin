using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public MonsterManager MonsterManager;

    public float attackRange = 10.0f;
    public float chaseRange = 30.0f;
    public float speed = 2.0f;
    public float attackSpeed = 0.5f;

    public bool canAttack;

    public Transform target;
    public NavMeshAgent navMeshAgent;

    public void Awake()
    {
        PlayerManager = GameObject.Find("GameManager").GetComponent<GameManager>().PlayerManager;
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = PlayerManager.transform;
    }

    void Update()//UNDO晃動 離地後開始亂走

    {
        navMeshAgent.SetDestination(target.transform.position); //UNDO
        float distance = Vector3.Distance(PlayerManager.transform.position, transform.position);

        if (distance <= attackRange)
        {
            transform.LookAt(target.transform.position);
            if (canAttack)
            {
                canAttack=false;
                attackSpeed = 0.5f;
                MonsterManager.LineSkill();
            }
            navMeshAgent.SetDestination(transform.position); //UNDO
        }
        else if (distance <= chaseRange)
        {
            navMeshAgent.SetDestination(target.transform.position); //UNDO
        }
        
        attackSpeed -= Time.deltaTime;
        if (attackSpeed < 0)
        {
            canAttack = true;
            attackSpeed = 0.5f;
        }

    }
}
