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
        points = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("touch"); 
            float new_Points = Points.removePoints();
            points += new_Points;
            UIPoints.text = "Δενόγθ: " + points.ToString();
            moveUp.moveDown(); 
        }
    }
} 
 