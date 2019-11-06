using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class CharacterMoveComponent : MonoBehaviour
{
    private bool running;
    private float speed;
    private float direction;
    private bool grounded;
    private Vector3 jump;
    public float jumpForce = 2.0f;
    public GameObject inventoryUI;
    Animator anim;
    Rigidbody rb;
    public GameObject target;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("dead") && !inventoryUI.activeSelf)
        {
            grounded = anim.GetBool("Grounded");
            direction = Input.GetAxis("Horizontal");
            speed = Input.GetAxis("Vertical");

            anim.SetFloat("Direction", direction);
            anim.SetFloat("Speed", speed);

            if (Input.GetButtonDown("Jump") && grounded)
            {
                anim.SetTrigger("Jump");
                //anim.applyRootMotion = true;
                anim.SetBool("Grounded", false);
                jump = new Vector3(direction, 20.0f, speed);
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            }
            if (Input.GetButton("Run"))
            {
                anim.SetBool("Run", !anim.GetBool("Run"));
            }
            if (Input.GetKey(KeyCode.Tab))
            {
                transform.LookAt(target.transform);
            }
        }
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
    //PlaceHolders pour des fonctions à problème avec certaine animations
    public void FootR() { }
    public void FootL() { }
}
