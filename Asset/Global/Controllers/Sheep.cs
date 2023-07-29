using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sheep : MonoBehaviour
{
    public GameObject Player;

    public float EscapeDistance = 4.0f;
    
    [Header("Controll")]
    private NavMeshAgent mAgent;

    [Header("Animator")]
    private Animator Animator;

    [Header("State")]
    private bool mIsDead = false;

    [Header("Info")]
    public GameObject[] Item = null;

    // Use this for initialization
    void Start()
    {
        mAgent = GetComponent<NavMeshAgent>();

        Animator = GetComponent<Animator>();
    }

    private bool IsNavMeshMoving
    {
        get
        {
            return mAgent.velocity.magnitude > 0.1f;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (mIsDead)
            return;


        // Performance optimization: Thx to kyl3r123 :-)
        float squaredDist = (transform.position - Player.transform.position).sqrMagnitude;
        float EscapeDistanceSqrt = EscapeDistance * EscapeDistance;

        // Run away from player
        if (squaredDist < EscapeDistanceSqrt)
        {
            // Vector player to me
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position + dirToPlayer;

            mAgent.SetDestination(newPos);

        }

        Animator.SetBool("walk", IsNavMeshMoving);

    }
}
