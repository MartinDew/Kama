using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckButtonsPressed : MonoBehaviour
{
    GameObject inventory;
    private void Start()
    {
        inventory = GameObject.Find("Inventory");
        inventory.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("PauseMenuScene");
        }
    }
}
