using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillageTrigger : MonoBehaviour
{
    private Collider playerCollider;
    public Text questText;
    AudioSource audioSource;
    private AudioClip oldMusic;
    public AudioClip villageMusic;

    private void Start()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Main Character").GetComponent<Collider>();
        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();
        oldMusic = audioSource.clip;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider == playerCollider)
        {
            // Changer la quête
            if (questText.text == "- Trouver le village")
                questText.text = "- Parler à Arthur";

            // Jouer la musique du village
            audioSource.clip = villageMusic;
            audioSource.volume = .5f;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider == playerCollider)
        {
            // Jouer la musique du monde
            audioSource.clip = oldMusic;
            audioSource.volume = .5f;
            audioSource.Play();
        }
    }
}
