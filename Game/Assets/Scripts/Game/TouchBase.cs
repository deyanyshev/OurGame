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
            Points.points1_base += Points.points1;
            Points.points1 = 0;
            UIPoints.text = "Δενόγθ: " + Points.points1_base.ToString();

            Debug.Log(Points.points1_base);
        }
        else if (other.tag == "Enemy" && Points.points2 == 0)
        {
            if (Points.points1_base >= Points.max_point2)
            {
                Points.points2 = Points.max_point2;
                Points.points1_base -= Points.points2;
            }
            else
            {
                Points.points2 = Points.points1_base;
                Points.points1_base = 0;
            }
            UIPoints.text = "Δενόγθ: " + Points.points1_base.ToString();
        }
    }
} 
 