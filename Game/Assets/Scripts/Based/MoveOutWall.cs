using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOutWall : MonoBehaviour
{

    public int power_down = 1;
    public int power = 2;
    private Rigidbody rbody;
    public Collider player;

    private void Start() {
        
        transform.position = new Vector3(Random.Range(-270, 0), 30, Random.Range(-150, 105));
        rbody = GetComponent<Rigidbody>();
        rbody.velocity = new Vector3(Random.Range(-power, power), -power_down, Random.Range(-power, power));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            transform.position = new Vector3(Random.Range(-270, 0), 30, Random.Range(-150, 105));
            transform.rotation = new Quaternion(0, 0, 0, 0);
            rbody = GetComponent<Rigidbody>();
            rbody.velocity = new Vector3(Random.Range(-power, power), -power_down, Random.Range(-power, power));
        }
    }
}
