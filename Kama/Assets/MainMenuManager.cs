using System.IO;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    void Start()
    {
        if (File.Exists(SaveWhenPausing.path))
            File.Delete(SaveWhenPausing.path);
    }
}
