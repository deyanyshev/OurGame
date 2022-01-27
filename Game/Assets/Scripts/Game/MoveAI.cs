using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveAI : MonoBehaviour
{
    public Text UIPoints;
    public GameObject Player;

    private Camera cam;
    private NavMeshAgent agent;
    private List<Vector3> list;
    private Vector3 base_player;
    private Vector3 pos;
    private bool status;
    private float len_path;

    void Start()
    {
        status = true;
        if (SceneManager.GetActiveScene().name == "First")
        {
            list = new List<Vector3> { new Vector3(20, 3, -130), new Vector3(20, 3, 110), new Vector3(-215, 3, 125), new Vector3(-295, 3, 10) };
            base_player = new Vector3(-180, 0, -2);
        }
        else if (SceneManager.GetActiveScene().name == "Second")
        {
            // временно(данные не верны)
            list = new List<Vector3> { new Vector3(20, 3, -130), new Vector3(20, 3, 110), new Vector3(-215, 3, 125), new Vector3(-295, 3, 10) };
            base_player = new Vector3(-180, 0, -2);
        }
        cam = Camera.main;
        Vector3 v = list[Random.Range(0, 3)];
        pos = v;
        transform.position = v;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(base_player);
        len_path = Getdist(base_player);
        agent.angularSpeed = 180;
    }

    void Update()
    {
        if (status)
        {
            if (len_path - Getdist(base_player) > 0)
            {
                agent.SetDestination(base_player);
            }
            len_path = Getdist(base_player);
        }
        else
        {
            float dist1 = Getdist(list[0]);
            float dist2 = Getdist(list[1]);
            float dist3 = Getdist(list[2]);
            float dist4 = Getdist(list[3]);
            if (len_path - System.Math.Min(dist1, System.Math.Min(dist2, System.Math.Min(dist3, dist4))) > 0)
            {
                GoBase(dist1, dist2, dist3, dist4);
            }
            len_path = System.Math.Min(dist1, System.Math.Min(dist2, System.Math.Min(dist3, dist4)));
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
        else if (!agent.hasPath && status)
        {
            agent.SetDestination(base_player);
            len_path = Getdist(base_player);
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
            Points.points2_base += Points.points2;
            Points.points2 = 0;
            UIPoints.text = Points.points2_base.ToString() + " :Деньги";
            status = true;
        }
        else if (other.tag == "Player" && other.GetType() == typeof(BoxCollider))
        {
            Points.points1 += Points.points2;
            Points.points2 = 0;
            transform.position = list[Random.Range(0, 3)];
            status = true;
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
