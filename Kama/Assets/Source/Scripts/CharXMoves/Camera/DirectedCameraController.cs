using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class DirectedCameraController : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);
        //float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //transform.Rotate(vertical, 0, 0);


        float desiredAngleY = target.transform.eulerAngles.y;


        Quaternion rotation = Quaternion.Euler(0, desiredAngleY, 0);
        transform.position = target.transform.position - (rotation * offset);
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition, target.transform.up);
    }
}
