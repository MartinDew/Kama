using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenOptions : MonoBehaviour
{
    public void GotoOptions()
    {
        SceneManager.LoadScene("OptionsMenuScene");
    }
}
