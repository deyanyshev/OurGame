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
    /*
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                print(hit.point);
                agent.SetDestination(hit.point);
            }
        }
    }*/
}
