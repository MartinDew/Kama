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
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("PauseMenuScene");
        }
    }
}
