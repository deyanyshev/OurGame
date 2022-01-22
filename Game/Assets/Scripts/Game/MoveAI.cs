using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MoveAI : MonoBehaviour
{
    public Text UIPoints;
    public GameObject Player;

    private Camera cam;
    private NavMeshAgent agent;
    private List<Vector3> list;
    private Vector3 pos;
    private bool status; // Он идёт к себе на базу или на чужую
    private float tps;
    private float len_path;

    void Start()
    {
        status = true;
        tps = 0;
        list = new List<Vector3> { new Vector3(20, 3, -130), new Vector3(20, 3, 110), new Vector3(-215, 3, 125), new Vector3(-295, 3, 10) };
        cam = Camera.main;
        Vector3 v = list[Random.Range(0, 3)];
        pos = v;
        transform.position = v;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(new Vector3(-180, 0, -2));
        len_path = Getdist(new Vector3(-180, 0, -2));
        agent.angularSpeed = 180;
    }

    void Update()
    {
        ++tps;
        len_path -= (agent.speed / 1000);
        if (tps > 50)
        {
            if (status)
            {
                tps = 0;
                float new_dist = Getdist(new Vector3(-180, 0, -2));
                NavMeshPath path = agent.path;
                float old_dist = 0;
                for (int i = 1; i < path.corners.Length; ++i)
                {
                    old_dist += Vector3.Distance(path.corners[i - 1], path.corners[i]);
                }
                if (old_dist == 0)
                {
                    old_dist = len_path;
                }
                if (new_dist < old_dist)
                {
                    agent.SetDestination(new Vector3(-180, 0, -2));
                }
            }

        }
        if (!agent.hasPath && !status)
        {
            float dist1 = Getdist(list[0]);
            float dist2 = Getdist(list[1]);
            float dist3 = Getdist(list[2]);
            float dist4 = Getdist(list[3]);

            if (list[0] == pos)
            {
                dist1 = 100000000;
            }
            else if(list[1] == pos)
            {
                dist2 = 100000000;
            }
            else if (list[2] == pos)
            {
                dist3 = 100000000;
            }
            else if (list[3] == pos)
            {
                dist4 = 100000000;
            }

            GoBase(dist1, dist2, dist3, dist4);
        }
    }


    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "Base")
        {
            float dist1 = Getdist(list[0]);
            float dist2 = Getdist(list[1]);
            float dist3 = Getdist(list[2]);
            float dist4 = Getdist(list[3]);
            GoBase(dist1, dist2, dist3, dist4);
            status = false;
        }
        else if (other.tag == "Base2")
        {
            agent.SetDestination(new Vector3(-180, 0, -2));
            Points.points2_base += Points.points2;
            Points.points2 = 0;
            UIPoints.text = Points.points2_base.ToString() + " :Деньги";
            status = true;
            len_path = Getdist(new Vector3(-180, 0, -2));
        }
        else if (other.tag == "Player" && other.GetType() == typeof(BoxCollider))
        {
            Points.points1 += Points.points2;
            Points.points2 = 0;
            transform.position = list[Random.Range(0, 3)];
            agent.SetDestination(new Vector3(-180, 0, -2));
            len_path = Getdist(new Vector3(-180, 0, -2));
            status = true;
            Debug.Log(Points.points1);
        }
    }

    private float Getdist(Vector3 target)
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(target, path);
        float dist = 0;
        for (int i = 0; i < path.corners.Length - 1; ++i)
        {
            dist += Vector3.Distance(path.corners[i], path.corners[i + 1]);
        }
        return dist;
    } 

    private void GoBase(float dist1, float dist2, float dist3, float dist4)
    {

        if (dist1 < dist2 && dist1 < dist3 && dist1 < dist4)
        {
            agent.SetDestination(list[0]);
            pos = list[0];
        }
        else if (dist2 < dist1 && dist2 < dist3 && dist2 < dist4)
        {
            agent.SetDestination(list[1]);
            pos = list[1];
        }
        else if (dist3 < dist1 && dist3 < dist2 && dist3 < dist4)
        {
            agent.SetDestination(list[2]);
            pos = list[2];
        }
        else if (dist4 < dist1 && dist4 < dist2 && dist4 < dist3)
        {
            agent.SetDestination(list[3]);
            pos = list[3];
        }
        len_path = Getdist(pos);
    }
}
