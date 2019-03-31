using UnityEngine.AI;
using UnityEngine;

public class FriendAI : MonoBehaviour
{
    public GameObject objective;
    public NavMeshAgent Agent;

    void Start()
    {
        //Agent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Agent.SetDestination(objective.transform.position);
    }
}
