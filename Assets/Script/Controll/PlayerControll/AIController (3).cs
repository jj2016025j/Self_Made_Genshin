using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIController : MonoBehaviour
{
    [Header("ObjectInfo")]
    public List<characterstats> targets;
    public characterstats target;
    public characterstats own;
    public NavMeshAgent agent;
    public LayerMask GroundLayer, PlayerLayer;
    public playerManager2 playerManager;
    public GameObject Projectile;//發射的東西
    [Header("Numerical Value")]
    public float sightRange;
    public float attackRange;
    public float PatrolRange;//巡邏範圍
    public bool targetInSightRange;
    public bool targetInAttackRange;
    public bool canAttack = true;
    public Vector3 walkPoint;
    public bool walkPointIsSet = false;
    public float TimeToWaitAttack;
    private void Awake()
    {
        FindTargetForCanAttack(targets);
        target = 隨機目標(targets);
        target = 最近目標(targets);
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        own = GetComponent<characterstats>();

    }
    private void Update()
    {
        /*targetInSightRange = Physics.CheckSphere(transform.position, sightRange, PlayerLayer);
        targetInAttackRange = Physics.CheckSphere(transform.position, attackRange, PlayerLayer);
        if (!targetInSightRange && !targetInAttackRange) Patroling();
        if (targetInSightRange && !targetInAttackRange) Chasing();
        if (targetInSightRange && targetInAttackRange) Attacking();*/
        target = 最近目標(targets);

        if (Vector3.Distance(target.transform.position, transform.position)>= sightRange) Patroling();
        else if(Vector3.Distance(target.transform.position, transform.position)< sightRange) Chasing();
        else if(Vector3.Distance(target.transform.position, transform.position)< attackRange) Attacking();
    }
    private void Attacking()
    {
        agent.SetDestination(transform.position);
        if (canAttack)
        {
            /*Rigidbody rb = Instantiate(Projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
            rb.AddForce(transform.up * 10f, ForceMode.Impulse);*/
            transform.LookAt(target.transform);
            playerManager.指向技能();
            canAttack = false;
            Invoke(nameof(ResetAttack), TimeToWaitAttack);
        }
        Debug.Log("Attacking");

    }
    private void ResetAttack()
    {
        canAttack = true;
    }

    private void Chasing()
    {
        agent.SetDestination(target.transform.position);
        if ((target.transform.position - transform.position).magnitude < attackRange) Attacking();
        Debug.Log("Chasing");

    }

    private void Patroling()
    {
        if (!walkPointIsSet)
        {
            WalkPoint();
            walkPointIsSet = true;
        }
        if ((walkPoint - transform.position).magnitude < sightRange)
        {
            WalkPoint();
        }
        agent.SetDestination(walkPoint);
        Debug.Log("Patroling");
    }

    private void WalkPoint()
    {
        float randomX = Random.Range(-PatrolRange, PatrolRange);
        float randomZ = Random.Range(-PatrolRange, PatrolRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        walkPoint = NavMesh.SamplePosition(walkPoint, out NavMeshHit hit, PatrolRange, 1) ? hit.position : transform.position;
    }

    void FindTargetForCanAttack(List<characterstats> targets)
    {
        targets.Clear();
        var foundTargets = FindObjectsOfType<characterstats>();

        foreach (var foundTarget in foundTargets)
        {
            if (foundTarget != own)
            {
                targets.Add(foundTarget);
            }
        }
    }
    public characterstats 隨機目標(List<characterstats> targets)
    {
        characterstats target = targets[Random.Range(0, targets.Count)];
        if (target.transform.GetComponent<characterstats>() == own && target.objectState != characterdata.ObjectState.Dead)
        {
            target = 隨機目標(targets);
        }
        return target;
    }
    public characterstats 最近目標(List<characterstats> targets)
    {
        characterstats clossOne = targets[0];
        float minDis = Vector3.Distance(targets[0].transform.position, transform.position);
        if (targets[0].transform == transform)
        {
            if (targets[1].transform != null)
            {
                clossOne = targets[1];
                minDis = Vector3.Distance(targets[1].transform.position, transform.position);
            }
            else if (targets[1].transform == null) clossOne = null;
        }
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].transform != transform)
            {
                float dis = Vector3.Distance(targets[i].transform.position, transform.position);
                if (minDis > dis && targets[i].objectState != characterdata.ObjectState.Dead)
                {
                    minDis = dis;
                    clossOne = targets[i];
                }
            }
        }
        return clossOne;
    }
}
class test1{
    AIController aIController;
    public void OnDrawGizmosSelected()
{
    Gizmos.color = Color.black;
    Gizmos.DrawWireSphere(aIController.transform.position, aIController.attackRange);
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(aIController.transform.position, aIController.sightRange);
}
}
