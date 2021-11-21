using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchBase : MonoBehaviour
{
    public Text UIPoints;
    public MoveUpCam moveUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            float new_Points = Points.points1;
            Points.points1 = 0;
            Points.points1_base += new_Points;
            UIPoints.text = "Δενόγθ: " + Points.points1_base.ToString();
            moveUp.moveDown(); 
        }
        else if (other.tag == "Enemy")
        {
            Points.points2 += Points.points1_base;
            Points.points1_base = 0;
            UIPoints.text = "Δενόγθ: " + Points.points1_base.ToString();
        }
    }
} 
 