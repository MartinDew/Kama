using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonTrigger : MonoBehaviour
{
    AudioSource audioSource;
    private AudioClip oldMusic;
    public AudioClip dungeonMusic;
    public Text questText;
    private Collider playerCollider;
    new private Light light;
    private QuestManager questManager;

    private void Start()
    {
        questManager = GameObject.Find("GameManager").GetComponent<QuestManager>();
        playerCollider = GameObject.FindGameObjectWithTag("Main Character").GetComponent<Collider>();
        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();
        oldMusic = audioSource.clip;
        light = GameObject.Find("Directional Light").GetComponent<Light>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider == playerCollider)
        {
            // Changer la luminosité
            light.intensity = 0;

            // Changer la quête du donjon
            //if (questText.text == "- Entrer dans le donjon")
            //    questText.text = "- Trouver et vaincre Kragz";

            if (questManager.GetActiveQuest() == 5)
                questManager.SetActiveQuest(questManager.GetActiveQuest() + 1);

            // Jouer la musique du donjon
            audioSource.clip = dungeonMusic;
            audioSource.volume = .5f;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider == playerCollider)
        {
            // Changer la luminosité
            light.intensity = 1;

            // Jouer la musique du monde
            audioSource.clip = oldMusic;
            audioSource.volume = .5f;
            audioSource.Play();
        }
    }
}
