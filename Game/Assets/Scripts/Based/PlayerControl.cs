using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public AnimatorController anim;
    public float powerForward, powerBack, powerLR, power;
    private Rigidbody rbody;
    public Transform Handle;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        InvokeRepeating("Move", 0, 0.1f);
    }

    private void Move()
    {
        Vector3 MotionInput = transform.rotation * new Vector3(Handle.localPosition.x * powerLR, 0, Handle.localPosition.y) * power;

        if (MotionInput.z <= 0) MotionInput.z *= powerBack;
        else MotionInput.z *= powerForward;

        rbody.velocity = MotionInput;
        anim.ChooseAnimation(Handle.localPosition.x, Handle.localPosition.y);
    }
}
