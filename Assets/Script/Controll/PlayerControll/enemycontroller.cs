using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//怪物移動到玩家身邊後不會面向玩家
//待解決問題
//Follow持續被觸發
public enum EnemyStates
{ 
    Guard,
    Patrol,
    Chase,
    Dead,
    Attack
}
[RequireComponent(typeof(NavMeshAgent))]
public class enemycontroller : MonoBehaviour
{
    
    [Header("Basic Setting")]
    public EnemyStates enemyStates;
    private NavMeshAgent agent;
    public GameObject attackTarget;
    public characterstats characterstats;
    public Animator anim;
    public float sightRadius;//半徑
    private float speed;
    bool isWalk;
    bool isChase;
    bool isFollow;
    bool isAttack;
    bool isDead;
    public bool isGuard;
    public float countdownTime;
    public Collider coll;

    [Header("Patrol State")]
    private float patrolRange;
    private Vector3 waypoint;
    private Vector3 guardPos;
    private Quaternion guardRot;

    [Header("Guard State")]
    private float GuardTime;
    private float CurrentGuardTime;


    private void Awake()
    {
        patrolRange = sightRadius;
        agent = GetComponent<NavMeshAgent>();
        characterstats= GetComponent<characterstats>();
        anim = GetComponent<Animator>();
        speed = (agent.speed==null)?agent.speed:2;
        guardPos = transform.position;
        GuardTime = (GuardTime == null)?10: GuardTime;
        GuardTime = Random.Range(0, GuardTime);
        coll = GetComponent<Collider>();
    }
    private void Start()
    {
        if (isGuard)
        {
            enemyStates = EnemyStates.Guard;
        }
        else
        {
            enemyStates = EnemyStates.Patrol;
            GetNewWayPoint();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            enemyStates = EnemyStates.Dead;
        }
        else if (FoundPlayer())
        {
            enemyStates = EnemyStates.Chase;
            print("找到敵人了");
        }
        SwitchStates();
        SwitchAnimator();
    }
    void SwitchAnimator()//動畫
    {
        anim.SetBool("Attack", isAttack);
        anim.SetBool("Chase", isChase);//進入追擊狀態
        anim.SetBool("Follow", isFollow);//正在追擊
        anim.SetBool("Walk", isWalk);
        anim.SetBool("Death", isDead);
    }
    void SwitchStates()//狀態
    {
        switch (enemyStates)
        {
            case EnemyStates.Guard://給待命時間，時間過後進入巡邏狀態
                isChase = false;
                if (transform.position != guardPos) {
                    {
                        isWalk = true;
                        agent.isStopped = false;
                        agent.destination = guardPos;
                    } }
                if (Vector3.SqrMagnitude(guardPos - transform.position) <= agent.stoppingDistance)
                {
                    isWalk = false;
                    transform.rotation = Quaternion.Lerp(transform.rotation, guardRot, 0.1f);
                }
                /**/
                break;
            case EnemyStates.Patrol://停止追擊狀態，進入巡邏狀態，到達指定區域後重新設立目標地點進入待命狀態
                isChase = false;
                agent.speed = speed * 0.5f;
                if (Vector3.Distance(waypoint, transform.position) <= agent.stoppingDistance)
                {
                    isWalk = false;
                    
                    
                    //enemyStates = EnemyStates.Guard;
                }
                else
                {
                    isWalk = true;
                    agent.destination = waypoint;
                }
                break;
            case EnemyStates.Chase:
                //追Player
                //進入攻擊
                //動畫
                isWalk = false;
                agent.speed = speed;
                isChase = true;
                if (!FoundPlayer())
                {
                    isChase = false;
                    isFollow = false;
                    agent.destination = transform.position;
                    enemyStates = EnemyStates.Guard;
                    if (CurrentGuardTime <= GuardTime)
                    {
                        CurrentGuardTime += Time.deltaTime;
                    }
                    else
                    {
                        CurrentGuardTime = 0;
                        GuardTime = Random.Range(0, GuardTime);
                        //enemyStates = EnemyStates.Patrol;
                        GetNewWayPoint();
                    }
                }
                else
                {
                    isFollow = true;
                    agent.isStopped = false;
                    agent.destination = attackTarget.transform.position;
                    if (TargetInAttackRange() || TargetInSkillRange())
                    {
                        //enemyStates = EnemyStates.Attack;
                        
                        isFollow = false;
                        agent.isStopped = true;
                        if (countdownTime < characterstats.CharacterData.coolDown)
                        {
                            countdownTime += Time.deltaTime;
                        }
                        else
                        {
                            countdownTime = 0;
                            Attack();
                        }
                        transform.LookAt(attackTarget.transform);
                        //Debug.Log("追擊到攻擊");
                    }
                }

                break;
            case EnemyStates.Attack:

                break;
            case EnemyStates.Dead:
                coll.enabled = false;
                agent.enabled = false;
                Destroy(gameObject, 2f);
                break;
        }
    }
    void Attack()
    {
        Debug.Log("普通攻擊");
        anim.SetTrigger("attack");
        characterstats.iscritical = Random.value < characterstats.CharacterData.criticalchance;//計算爆擊
        if (characterstats.iscritical)//如果爆擊
        {
            Debug.Log("爆擊");
            anim.SetTrigger("Skill");
            characterstats.iscritical = true;
        }
        else characterstats.iscritical =false;
    }
    bool FoundPlayer()
    {
        var colloders = Physics.OverlapSphere(transform.position,sightRadius);
        foreach(var target in colloders)
        {
            if (target.CompareTag("Player"))
            {
                attackTarget = target.gameObject;
                return true;
            }
        }
        attackTarget = null;
        return false;
    }
    bool TargetInAttackRange()
    {
        if (attackTarget != null)
            return Vector3.Distance(attackTarget.transform.position, transform.position) <= characterstats.CharacterData.attackRange;
        else return false;
    }
    bool TargetInSkillRange()
    {
        if (attackTarget != null)
            return Vector3.Distance(attackTarget.transform.position, transform.position) <= characterstats.CharacterData.skillRange;
        else return false;

    }


    void GetNewWayPoint()
    {
        float randomx = Random.Range(-patrolRange, patrolRange);
        float randomz = Random.Range(-patrolRange, patrolRange);
        waypoint = new Vector3(guardPos.x + randomx, transform.position.y, guardPos.z + randomz);
        NavMeshHit hit;
        waypoint = NavMesh.SamplePosition(waypoint, out hit, patrolRange, 1) ? hit.position : transform.position;
        Debug.Log("換一個位置");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(guardPos, sightRadius);
    }
    void Hit()
    {
        if (attackTarget != null)
        {
            var targetStats = attackTarget.GetComponent<characterstats>();
            targetStats.TakeDamage(characterstats, targetStats);
            Debug.Log("怪物攻擊玩家");

        }
    }

}
