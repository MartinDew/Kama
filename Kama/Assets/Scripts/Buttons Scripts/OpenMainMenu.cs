using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMainMenu : MonoBehaviour
{
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
