using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    static private Transform player;
    float distance;

    private void Start() => 
        player = GameObject.FindGameObjectWithTag("Main Character").transform;

    void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
                Interact();
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Item has been interracted");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
