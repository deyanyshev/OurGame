using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MoveAI : MonoBehaviour
{
    public Text UIPoints;

    private Camera cam;
    private NavMeshAgent agent;
    private List<Vector3> list;


    void Start()
    {
        list = new List<Vector3> { new Vector3(20, 0, -130), new Vector3(20, 0, 110), new Vector3(-215, 0, 125), new Vector3(-295, 0, 10) };
        cam = Camera.main;
        //transform.position = list[Random.Range(0, 3)];
        transform.position = new Vector3(-140, 0, 2);
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(new Vector3(-170, 0, -2));
        agent.angularSpeed = 180;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Base")
        {
            
            float dist1 = Getdist(list[0]);
            float dist2 = Getdist(list[1]);
            float dist3 = Getdist(list[2]);
            float dist4 = Getdist(list[3]);
            
            if (dist1 > dist2 && dist1 > dist3 && dist1 > dist4)
            {
                agent.SetDestination(new Vector3(20, 0, -130));
            }
            else if (dist2 > dist1 && dist2 > dist3 && dist2 > dist4)
            {
                agent.SetDestination(new Vector3(20, 0, 110));
            }
            else if (dist3 > dist1 && dist3 > dist2 && dist3 > dist4)
            {
                agent.SetDestination(new Vector3(-215, 0, 125));
            }
            else if (dist4 > dist1 && dist4 > dist2 && dist4 > dist3)
            {
                agent.SetDestination(new Vector3(295, 0, 10));
            }
        }
        else if (other.tag == "Base2")
        {
            agent.SetDestination(new Vector3(-170, 0, -2));
            Points.points2_base += Points.points2;
            Points.points2 = 0;
            UIPoints.text = Points.points2_base.ToString() + " :������";
        }
        else if (other.tag == "Player")
        {
            Points.points1 += Points.points2;
            Points.points2 = 0;
            transform.position = list[Random.Range(0, 3)];
            agent.SetDestination(new Vector3(-170, 0, -2));
        }
    }

    private float Getdist(Vector3 target)
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(target, path);
        float dist = Vector3.Distance(transform.position, path.corners[1]);
        for (int i = 1; i < path.corners.Length - 1; ++i)
        {
            dist += Vector3.Distance(path.corners[i], path.corners[i + 1]);
        }
        return dist;
    } 
}
