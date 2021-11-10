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
        transform.position = new Vector3(Random.Range(-270, 0), 30, Random.Range(-150, 105));
        rbody.AddForce(new Vector3(Random.Range(-power, power), -power_down, Random.Range(-power, power)), ForceMode.Impulse);
    }
}
