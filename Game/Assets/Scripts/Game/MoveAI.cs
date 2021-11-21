using UnityEngine;
using UnityEngine.AI;

public class MoveAI : MonoBehaviour
{

    private Camera cam;
    private NavMeshAgent agent;

    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(new Vector3(-162, 0, -2));
    }

    void Update()
    {
        
    }
}
