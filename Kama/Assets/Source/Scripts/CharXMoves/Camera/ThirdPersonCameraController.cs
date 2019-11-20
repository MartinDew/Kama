using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;
    float rayDistance;
    float originalDistance;

    public Transform Obstruction;
    float zoomSpeed = 2f;

    private void Start()
    {
        originalDistance = Vector3.Distance(transform.position, Target.transform.position);
        Obstruction = Target;
        Player = PlayerManager.instance.player.transform;   
    }
    void LateUpdate()
    {
        CamControl();
        ViewObstructed();
    }

    private void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }

    }

    private void ViewObstructed()
    {
        RaycastHit hit;
        rayDistance = Vector3.Distance(transform.position, Target.transform.position);
        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, rayDistance))
        {
            Debug.Log(Obstruction.gameObject.name);
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag != "Main Character")
            {
                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            
                if (Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
            else
            {
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if (Vector3.Distance(transform.position, Target.position) < originalDistance)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * rayDistance;
        Gizmos.DrawRay(transform.position, direction);
    }
}
