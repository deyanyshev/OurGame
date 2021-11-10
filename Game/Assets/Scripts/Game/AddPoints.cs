using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPoints : MonoBehaviour
{
    public float points;
    public Text UIPoints;

    public void Update()
    {
        UIPoints.text = "Мана: " + points.ToString();
    }

    public void addPoints()
    {
        points += Random.Range(20, 100);
    }
}
