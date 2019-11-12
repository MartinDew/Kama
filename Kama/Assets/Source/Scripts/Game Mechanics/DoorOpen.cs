using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : Interactable
{
    public override void Interact()
    {
        Destroy(gameObject);
    }
}
