using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDungeonQuest : MonoBehaviour
{
    public Collider playerCollider;
    public Text questText;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider == playerCollider)
        {
            if (questText.text == "- Entrer dans le donjon")
                questText.text = "- Trouver et vaincre Kragz";
        }
    }
}
