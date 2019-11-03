using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class LookAroundCameraController : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed;
    Vector3 offset;
    private float MoveX;
    private float MoveY;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        target.transform.Rotate(0, horizontal, 0);
        //float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //transform.Rotate(vertical, 0, 0);


        float desiredAngleY = target.transform.eulerAngles.y;

        offset = Quaternion.AngleAxis(horizontal, Vector3.up) * Quaternion.AngleAxis(vertical, Vector3.right) * offset;
        transform.position = target.transform.position + offset;
        transform.LookAt(target.transform.position);

        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");

        target.transform.Rotate(horizontal, 0, 0);
    }
}
