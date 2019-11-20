using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchNewGame : MonoBehaviour
{
    public void Launch()
    {
        SceneManager.LoadScene("GameScene");
    }
}