using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateVillageQuest : MonoBehaviour
{
    public Collider playerCollider;
    public Text questText;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider == playerCollider)
        {
            if (questText.text == "- Trouver le village")
                questText.text = "- Parler à Mike";
        }
    }
}
