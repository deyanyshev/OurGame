using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float power = 1;
    private Rigidbody rbody;
    public Transform Handle;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        InvokeRepeating("Move", 0, 0.1f);
    }

    private void Move()
    {
        Vector3 MotionInput = transform.rotation * new Vector3(Handle.localPosition.x, 0, Handle.localPosition.y) * power;
        rbody.velocity = MotionInput;
    }
}
