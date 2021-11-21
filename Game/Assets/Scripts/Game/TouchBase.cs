using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchBase : MonoBehaviour
{
    public AddPoints Points;
    public Text UIPoints;
    public MoveUpCam moveUp;

    private float points;

    void Start()
    {
        points = 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            float new_Points = Points.removePoints();
            points += new_Points;
            UIPoints.text = "Δενόγθ: " + points.ToString();
            moveUp.moveDown(); 
        }
        else if (other.tag == "Enemy")
        {
            Points.points2 = points;
            points = 0;
            UIPoints.text = "Δενόγθ: " + points.ToString();
        }
    }
} 
 