using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : Interactable
{
    public GameObject doorToOpen;
    private bool hasPlayed = false;

    public override void Interact()
    {
        Destroy(doorToOpen);

        if (!hasPlayed)
        {
            GetComponent<AudioSource>().Play();
            hasPlayed = true;
        }
    }
}
