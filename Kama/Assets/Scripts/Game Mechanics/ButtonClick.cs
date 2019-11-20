using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : Interactable
{
    public GameObject doorToOpen;
    public Canvas interactCanvas;
    private bool hasPlayed = false;

    public override void Interact()
    {
        Destroy(doorToOpen);
        interactCanvas.enabled = false;

        if (!hasPlayed)
        {
            GetComponent<AudioSource>().Play();
            hasPlayed = true;
        }
    }
}
