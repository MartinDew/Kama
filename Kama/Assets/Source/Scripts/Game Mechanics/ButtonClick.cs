using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : Interactable
{
    public GameObject doorToOpen;

    public override void Interact()
    {
        Destroy(doorToOpen);
    }
}
