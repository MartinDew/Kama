using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchNewGame : MonoBehaviour
{
    public void Launch()
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
        SceneManager.LoadScene("GameScene");
    }
}