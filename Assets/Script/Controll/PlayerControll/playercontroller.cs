using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playercontroller2 : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public GameObject attackTarget;
    public characterstats characterstats;
    public float LastAttakTime;
    private bool isDead;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        characterstats = GetComponent<characterstats>();
    }
    public void Start()
    {
        mousemanager.Instance.OnMouseClicked += MoveToTarget;
        mousemanager.Instance.OnEnemyClicked += EventAttack;
    }


    public void Update()
    {
        isDead = characterstats.currentHealth == 0;
        LastAttakTime -= Time.deltaTime;
        SwitchAnmation();
    }
    public void SwitchAnmation()
    {
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
        animator.SetBool("Death", isDead);
    }
    public void MoveToTarget(Vector3 target)
    {
        StopAllCoroutines();
        agent.isStopped = false;
        agent.destination = target;
        MoveToStop();
    }
    IEnumerator MoveToStop()
    {
        while (Vector3.Distance(attackTarget.transform.position, transform.position) > agent.stoppingDistance)
        {
            //Debug.Log(Vector3.Distance(attackTarget.transform.position, transform.position));
            agent.destination = transform.position;
            agent.isStopped = true;
            yield return null;
        }
    }
    public void EventAttack(GameObject target)
    {
        if (target != null)
        {
            attackTarget = target;
            characterstats.iscritical= UnityEngine.Random.value<characterstats.CharacterData.criticalchance;
            StartCoroutine(MoveToAttactTarget());
        }
    }
    IEnumerator MoveToAttactTarget()
    {
        agent.isStopped = false;
        transform.LookAt(attackTarget.transform);
        //TODO:改變距離變數
        while (Vector3.Distance(attackTarget.transform.position, transform.position) > characterstats.CharacterData.attackRange)
        {
            //Debug.Log(Vector3.Distance(attackTarget.transform.position, transform.position));
            agent.destination = attackTarget.transform.position;
            yield return null;
        }
        agent.isStopped = true;
        //Attack
        if (LastAttakTime <= 0)
        {
            Debug.Log("Attack");
            animator.SetTrigger("Attack");
            animator.SetTrigger("Critical");
            LastAttakTime = characterstats.CharacterData.coolDown;
        }
    }
    void Hit()
    {
        var targetStats = attackTarget.GetComponent<characterstats>();
        targetStats.TakeDamage(characterstats, targetStats);
        Debug.Log("玩家攻擊怪物");

    }
}
