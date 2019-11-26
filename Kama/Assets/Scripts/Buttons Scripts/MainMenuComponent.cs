using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuComponent : MonoBehaviour
{
    void Start() => SaveSystem.LoadOnStart = false;
    public void LaunchNewGame() => SceneManager.LoadScene("GameScene");
    public void Load()
    {
        SaveSystem.LoadOnStart = true;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit() => Application.Quit();
}
