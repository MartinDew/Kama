using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundDetectedComponent : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();        
    }

    private void OnCollisionStay(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Map")
        {
            anim.SetBool("Grounded", true);
        }
    }
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Map")
        {
            anim.SetBool("Grounded", true);
            anim.applyRootMotion = true;
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Map")
        {
            //direction = Input.GetAxis("Horizontal");
            //speed = Input.GetAxis("Vertical");
            anim.SetBool("Grounded", false);
            //anim.applyRootMotion = false;
            // transform.position += new Vector3(speed, direction, 0);
        }
    }
}
