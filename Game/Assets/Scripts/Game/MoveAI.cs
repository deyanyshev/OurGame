using UnityEngine;
using UnityEngine.AI;

public class MoveAI : MonoBehaviour
{

    private Camera cam;
    private NavMeshAgent agent;
    private System.Collections.Generic.List<Vector3> list;



    void Start()
    {
        list = new System.Collections.Generic.List<Vector3> { new Vector3(20, 0, -130), new Vector3(20, 0, 110), new Vector3(-215, 0, 125), new Vector3(-295, 0, 10) };
        cam = Camera.main;
        transform.position = list[Random.Range(0, 3)];
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(new Vector3(-170, 0, -2));
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Base")
        {
            agent.SetDestination(new Vector3(20, 0, -130));
        }
        else if (other.tag == "Base2")
        {
            agent.SetDestination(new Vector3(-170, 0, -2));
        }
        else if (other.tag == "Player")
        {
            transform.position = list[Random.Range(0, 3)];
            agent.SetDestination(new Vector3(-170, 0, -2));
        }
    }
}
