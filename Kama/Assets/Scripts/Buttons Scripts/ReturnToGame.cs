using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGame : MonoBehaviour
{
    AudioSource gameSceneAudio;
    public void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("GameScene");
            gameSceneAudio = GameObject.Find("GameManager").GetComponent<AudioSource>();
            gameSceneAudio.mute = false;
        }
    }

    public void GotoGame()
    {
        SceneManager.LoadScene("GameScene");
        gameSceneAudio = GameObject.Find("GameManager").GetComponent<AudioSource>();
        gameSceneAudio.mute = false;
    }
}
