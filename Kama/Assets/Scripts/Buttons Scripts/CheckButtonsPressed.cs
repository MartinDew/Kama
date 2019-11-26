using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckButtonsPressed : MonoBehaviour
{
    GameObject inventory;
    GameObject save;
    GameObject load;
    public GameObject menu;
    public AudioSource swordSound;
    AudioSource gameSceneAudio;
    AudioSource menuSceneAudio;
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
        gameSceneAudio = GameObject.Find("GameManager").GetComponent<AudioSource>();
        menuSceneAudio = menu.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!menu.activeSelf)
                activateMenu();
            else
                disableMenu();
        }
    }

    public void activateMenu()
    {
        menu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameSceneAudio.mute = true;
        menuSceneAudio.Play();
        GameObject.Find("Player").GetComponent<PlayerComponent>().SkillConsumption = 0;
        swordSound.mute = true;
        Time.timeScale = 0;
    }

    public void disableMenu()
    {
        menu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameSceneAudio.mute = false;
        menuSceneAudio.Stop();
        GameObject.Find("Player").GetComponent<PlayerComponent>().SkillConsumption = 5;
        swordSound.mute = false;
        Time.timeScale = 1;
    }

    public void SaveGame()
    {
        PlayerComponent player = GameObject.Find("Player").GetComponent<PlayerComponent>();
        player.SavePlayer();
    }

    public void ReturnToMainMenu() => SceneManager.LoadScene("MainMenuScene");
}
