using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(Rigidbody))]

public class CharacterMoveComponent : MonoBehaviour
{
    private bool running;
    private float speed;
    private float direction;
    private bool grounded;
    public float speedAmp = 6.0f;
    public float gravity = 20.0f;
    private Vector3 jump;
    public float jumpForce = 2.0f;
    public GameObject inventoryUI;
    Animator anim;
    //Rigidbody rb;
    public GameObject target;
    CharacterController controller;
    //public float minClamp = -53f;
    private float vertVelocity = 0f;
    private float walkSpeed;
    private float runSpeed;

    private Vector3 moveDirection = Vector3.zero;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!anim.GetBool("dead") && !inventoryUI.activeSelf)
        {
            grounded = anim.GetBool("Grounded");
            direction = Input.GetAxis("Horizontal");
            speed = Input.GetAxis("Vertical");
            if (!anim.GetBool("Run"))
                speed /= 2;
            // Start the animations
            anim.SetFloat("Direction", direction);
            anim.SetFloat("Speed", speed);
            Debug.Log(controller.isGrounded);

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            ////transform.Translate(speed, 0, direction);  
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection.normalized * speedAmp;


            //  vertVelocity = 0f;
            if (Input.GetButtonDown("Jump") && controller.isGrounded)
            {
                anim.SetTrigger("Jump");
                anim.SetBool("Grounded", false);

                vertVelocity += jumpForce;
                vertVelocity = Mathf.Clamp(vertVelocity, gravity, jumpForce);
                moveDirection.y = vertVelocity;
                //jump = new Vector3(direction, 20.0f, speed);
                //rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                //controller.Move(new Vector3(0, jumpForce, 0) * Time.deltaTime);

            }

            // apply gravity
            vertVelocity += Physics.gravity.y * Time.deltaTime;
            vertVelocity = Mathf.Clamp(vertVelocity, gravity, jumpForce);
            moveDirection.y = vertVelocity;

            // Move the character 
            //controller.Move(distance);
            controller.Move(moveDirection * Time.deltaTime);


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
            //anim.applyRootMotion = true;
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
