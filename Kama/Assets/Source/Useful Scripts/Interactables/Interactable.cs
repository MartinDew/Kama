using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    float distance;
    private RectTransform interactText, interactBackground;
    private void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Main Character").transform;
        interactText = GameObject.Find("Interact Text").GetComponent<RectTransform>();
        interactBackground = GameObject.Find("Interact Text Background").GetComponent<RectTransform>();
    }

    void Update()
    {
        distance = Vector3.Distance(player.position, interactionTransform.position);
        // If we haven't already interacted and the player is close enough
        if (distance <= radius)
        {
            Debug.Log("Close enough to " + interactionTransform.name);
            interactBackground.gameObject.SetActive(true);
            interactText.gameObject.SetActive(true);

            if (Input.GetButtonDown("Use"))
                Interact();
        }
        else
        {
            interactBackground.gameObject.SetActive(false);
            interactText.gameObject.SetActive(false);
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
