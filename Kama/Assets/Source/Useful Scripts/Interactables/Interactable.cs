using UnityEngine;
using UnityEngine.AI;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    public Transform interactionTransform;
    private Transform player;       // Reference to the player transform

    bool isFocus = false;   // Is this interactable currently being focused?
    float distance;
    private void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Main Character").transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            distance = Vector3.Distance(player.position, interactionTransform.position);
            // If we haven't already interacted and the player is close enough
            if (distance <= radius)
            {
                // Interact with the object
                Interact();
            }
        }
    }

    // This method is meant to be overwritten
    public virtual void Interact()
    {
        Debug.Log("Item has been interracted");
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
