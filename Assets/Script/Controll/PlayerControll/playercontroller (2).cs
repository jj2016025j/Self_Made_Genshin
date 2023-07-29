using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playercontroller2 : MonoBehaviour
{
    public NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        mousemanager.Instance.OnMouseClicked += MoveToTarget;
    }
    public void MoveToTarget(Vector3 target)
    {
        agent.destination = target;
    }
}

