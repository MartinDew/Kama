using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuComponent : MonoBehaviour
{
    void Awake()
    {
        try
        {
            File.Delete(SaveWhenPausing.path);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
        SaveSystem.LoadOnStart = false;
        SaveWhenPausing.LoadOnUnpause = false;
    }
    public void LaunchNewGame() => SceneManager.LoadScene("GameScene");
    public void Load()
    {
        SaveSystem.LoadOnStart = true;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit() => Application.Quit();
}
