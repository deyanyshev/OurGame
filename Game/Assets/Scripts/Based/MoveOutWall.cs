using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOutWall : MonoBehaviour
{
    public float power_down = 2f, power = 4f;
    private Rigidbody rbody;
    public Collider player;
    public AddPoints addPoints;

    private void Start() 
    {
        rbody = GetComponent<Rigidbody>();
        InvokeRepeating("addForce", 0, 0.3f);
        spawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            addPoints.addPoints();
            spawn();
        }
    }

    public void spawn()
    {
        transform.position = new Vector3(Random.Range(-270, 0), 60, Random.Range(-150, 105));
    }

    void addForce()
    {
        if (transform.localPosition.y >= -25)
        {
            rbody.AddForce(new Vector3(Random.Range(-1, 1), -power_down, Random.Range(-1, 1)) * power, ForceMode.Impulse);
        }
    }
}
