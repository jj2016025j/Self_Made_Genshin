using UnityEngine;
using UnityEngine.AI;

public class nav : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();//���o����Agent����
    }
    void Update()
    {
        agent.SetDestination(target.position);//���o�ؼЪ���m
    }
}