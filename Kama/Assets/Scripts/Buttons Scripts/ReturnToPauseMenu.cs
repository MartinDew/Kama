using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToPauseMenu : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("PauseMenuScene");
        }
    }
    public void GotoPause()
    {
        SceneManager.LoadScene("PauseMenuScene");
    }
}
