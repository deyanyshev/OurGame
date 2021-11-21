using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchSecondBase : MonoBehaviour
{
    private float points;

    public Text UIPoints;
    public AddPoints Points;

    void Start()
    {
        points = 0;
        UIPoints.text = points.ToString() + " :Δενόγθ";
    }

    void Update()
    {
        UIPoints.text = points.ToString() + " :Δενόγθ";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            points += Points.points2;
            Points.points2 = 0;
            UIPoints.text = "Δενόγθ: " + points.ToString();
        }
    }
}
