using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckButtonsPressed : MonoBehaviour
{
    GameObject inventory;
    public GameObject menu;
    public AudioSource swordSound;
    AudioSource gameSceneAudio;
    AudioSource menuSceneAudio;
    private void Start()
    {
        inventory = GameObject.Find("Inventory");
        inventory.SetActive(false);
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
            {
                disableMenu();
            }
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
        GameObject.Find("ConfirmationText").SetActive(false);
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
