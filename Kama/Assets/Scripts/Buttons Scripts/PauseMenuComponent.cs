using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuComponent : MonoBehaviour
{
    AudioSource gameSceneAudio;
    private void Start()
    {
        SaveWhenPausing.LoadOnUnpause = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SaveWhenPausing.LoadOnUnpause = true;
            SceneManager.LoadScene("GameScene");
            gameSceneAudio = GameObject.Find("GameManager").GetComponent<AudioSource>();
            gameSceneAudio.mute = false;
        }
    }

    public void GotoGame()
    {
        SaveWhenPausing.LoadOnUnpause = true;
        SceneManager.LoadScene("GameScene");
        gameSceneAudio = GameObject.Find("GameManager").GetComponent<AudioSource>();
        gameSceneAudio.mute = false;
    }
    public void SaveGame()
    {
        PlayerComponent player = GameObject.Find("Player").GetComponent<PlayerComponent>();
        player.SavePlayer();
    }

    public void GotoMainMenu() => SceneManager.LoadScene("MainMenuScene");
}
