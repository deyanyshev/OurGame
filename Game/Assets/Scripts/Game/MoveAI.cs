using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class MoveAI : MonoBehaviour
{
    public Text UIPoints;

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

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Base")
        {
            agent.SetDestination(new Vector3(20, 0, -130));
        }
        else if (other.tag == "Base2")
        {
            agent.SetDestination(new Vector3(-170, 0, -2));
            print(Points.points2);
            Points.points2_base += Points.points2;
            Points.points2 = 0;
            UIPoints.text = Points.points2_base.ToString() + " :Δενόγθ";
        }
        else if (other.tag == "Player")
        {
            Points.points1 += Points.points2;
            Points.points2 = 0;
            transform.position = list[Random.Range(0, 3)];
            agent.SetDestination(new Vector3(-170, 0, -2));
        }
    }
}
