using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckButtonsPressed : MonoBehaviour
{
    GameObject inventory;
    GameObject save;
    GameObject load;
    private void Start()
    {
        inventory = GameObject.Find("Inventory");
        save = GameObject.Find("Save");
        load = GameObject.Find("Load");
        inventory.SetActive(false);
        save.SetActive(false);
        load.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Mis en commentaire le temps qu'on trouve un moyen de ne pas perdre notre sauvegarde quand on ouvre le menu de pause
        /*if (Input.GetKeyDown("escape"))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("PauseMenuScene");
        }*/
    }
}
