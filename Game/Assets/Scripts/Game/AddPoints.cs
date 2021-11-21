using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPoints : MonoBehaviour
{
    public float points;
    public float points2;

    public Text UIPoints;
    public MoveUpCam moveUp;

    public void Update()
    {
        UIPoints.text = "Мана: " + points.ToString();
    }

    public void addPoints()
    {
        int newPoints = Random.Range(20, 100);
        points += newPoints;
        moveUp.moveUp(newPoints);
    }

    public float removePoints()
    {
        float oldPoints = points;
        points = 0;
        return oldPoints;
    }
}
