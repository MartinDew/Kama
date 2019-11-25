using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuComponent : MonoBehaviour
{
    AudioSource gameSceneAudio;
    void Awake() => SaveSystem.LoadOnStart = false;

    public void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("GameScene");
            gameSceneAudio = GameObject.Find("GameManager").GetComponent<AudioSource>();
            gameSceneAudio.mute = false;
            PlayerComponent player = GameObject.Find("Player").GetComponent<PlayerComponent>();
            player.LoadTemp();
        }
    }

    public void GotoGame()
    {
        SceneManager.LoadScene("GameScene");
        gameSceneAudio = GameObject.Find("GameManager").GetComponent<AudioSource>();
        gameSceneAudio.mute = false;
        PlayerComponent player = GameObject.Find("Player").GetComponent<PlayerComponent>();
        player.LoadTemp();
    }
    public void SaveGame()
    {
        PlayerComponent player = GameObject.Find("Player").GetComponent<PlayerComponent>();
        player.SavePlayer();
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
