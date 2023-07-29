using UnityEngine;
using UnityEngine.AI;

public class nav : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();//取得物件的Agent元件
    }
    void Update()
    {
        agent.SetDestination(target.position);//取得目標的位置
    }
}