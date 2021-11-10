using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator anim;

    public void ChooseAnimation(float x, float y)
    {
        if (y == 0 && x == 0) 
        {
            anim.SetBool("isWalkForward", false);
            anim.SetBool("isWalkBack", false);
            anim.SetInteger("isLR", 0);
            anim.SetBool("isIdle", true);      
        } 
        
        else if (y < 0)
        {
            anim.SetInteger("isLR", 0);
            anim.SetBool("isWalkForward", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalkBack", true);
        }

        else if (x == 0 || Mathf.Abs(y / x) >= 1.5)
        {
            anim.SetInteger("isLR", 0);
            anim.SetBool("isWalkBack", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalkForward", true);
        }

        else
        {
            if (x < 0)
            {
                anim.SetBool("isWalkForward", false);
                anim.SetBool("isWalkBack", false);
                anim.SetBool("isIdle", false);
                anim.SetInteger("isLR", 1);
            }

            else
            {
                anim.SetBool("isWalkForward", false);
                anim.SetBool("isWalkBack", false);
                anim.SetBool("isIdle", false);
                anim.SetInteger("isLR", 2);
            }
        }
    }
}
