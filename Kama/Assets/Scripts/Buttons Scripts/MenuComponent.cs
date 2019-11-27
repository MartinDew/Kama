using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuComponent : MonoBehaviour
{
    
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void Load()
    {
        SaveSystem.LoadOnStart = true;
        SceneManager.LoadScene("GameScene");
    }
}
