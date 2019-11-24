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
            GameObject.Find("Player").GetComponent<PlayerComponent>().SaveTemp();
            SceneManager.LoadScene("PauseMenuScene");
        }
    }
    public void GotoPause()
    {
        GameObject.Find("Player").GetComponent<PlayerComponent>().SaveTemp();
        SceneManager.LoadScene("PauseMenuScene");
    }
}
