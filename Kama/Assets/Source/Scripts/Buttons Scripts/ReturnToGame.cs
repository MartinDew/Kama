using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGame : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown("i") || Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void GotoGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
