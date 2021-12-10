using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPoints : MonoBehaviour
{

    public Text UIPoints;
    public MoveUpCam moveUp;



    public void Update()
    {
        UIPoints.text = "Мана: " + Points.points1.ToString() + " / " + Points.max_point1;
    }

    public void addPoints()
    {
        int newPoints = Random.Range(20, 100);
        Points.points1 += newPoints;
        if (Points.points1 > Points.max_point1)
        {
            Points.points1 = Points.max_point1;
        }
        else
        {
            moveUp.moveUp((int)Points.points1);
        }
    }

}
