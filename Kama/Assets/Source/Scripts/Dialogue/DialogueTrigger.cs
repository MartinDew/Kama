using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interactable
{
    public Dialogue dialogue;

    public override void Interact()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
