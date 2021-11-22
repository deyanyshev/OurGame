using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    public AnimatorController anim;
    public float powerForward, powerBack, powerLR, power;
    public Transform Handle;
    public GameObject Player;
    private Rigidbody rbody;
    private NavMeshObstacle agent;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshObstacle>();
        InvokeRepeating("Move", 0, 0.1f);
    }

    private void Update()
    {
        var heading = transform.position - Player.transform.position;
        if (heading.magnitude < 35)
        {
            agent.enabled = false;
        }
        else
        {
            agent.enabled = true;
        }
    }
    private void Move()
    {
        Vector3 MotionInput = transform.rotation * new Vector3(Handle.localPosition.x * powerLR, 0, Handle.localPosition.y) * power;

        if (Handle.localPosition.y <= 0) MotionInput.z *= powerBack;
        else MotionInput.z *= powerForward;

        rbody.velocity = MotionInput;
        anim.ChooseAnimation(Handle.localPosition.x, Handle.localPosition.y);
    }
}
