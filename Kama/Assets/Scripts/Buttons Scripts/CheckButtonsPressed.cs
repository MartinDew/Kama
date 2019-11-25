using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckButtonsPressed : MonoBehaviour
{
    GameObject inventory;
    GameObject save;
    GameObject load;
    AudioSource gameSceneAudio;
    private void Start()
    {
        inventory = GameObject.Find("Inventory");
        save = GameObject.Find("Save");
        load = GameObject.Find("Load");
        inventory.SetActive(false);
        save.SetActive(false);
        load.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("Player").GetComponent<PlayerComponent>().SaveTemp();
            SaveWhenPausing.LoadOnUnpause = true;
            gameSceneAudio = GameObject.Find("GameManager").GetComponent<AudioSource>();
            gameSceneAudio.mute = true;
            SceneManager.LoadScene("PauseMenuScene", LoadSceneMode.Additive);
        }
    }
}
