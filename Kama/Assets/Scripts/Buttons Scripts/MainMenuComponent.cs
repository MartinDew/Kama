using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuComponent : MonoBehaviour
{
    Button loadButton;
    Image buttonImage;
    Text buttonText;
    void Start()
    {
        SaveSystem.LoadOnStart = false;
        loadButton = GameObject.Find("LoadGameButton").GetComponent<Button>();
        buttonImage = loadButton.GetComponent<Image>();
        buttonText = loadButton.GetComponentInChildren<Text>();

        if (File.Exists(SaveSystem.path))
        {
            loadButton.interactable = true;
            buttonImage.color = new Color(0, 0, 0, 1);
            buttonText.color = new Color(255, 255, 255, 1);
        }
        else
        {
            loadButton.interactable = false;
            buttonImage.color = new Color(0, 0, 0, 0);
            buttonText.color = new Color(255, 255, 255, .2f);
        }
    }
    public void LaunchNewGame()
    {
        if (File.Exists(SaveSystem.path))
            File.Delete(SaveSystem.path);

        SceneManager.LoadScene("GameScene");
    }
    public void Load()
    {
        SaveSystem.LoadOnStart = true;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit() => Application.Quit();
}
