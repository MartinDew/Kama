using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public float radius = 20f;
    public Text nameText;
    public Text dialogueText;
    public Text questText;
    public Image dialogueBox;
    //public Animator animator;
    private float distance;
    private Queue<string> sentences;
    private GameObject arthur;
    private GameObject lea;
    private GameObject entrance;
    private void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.gameObject.SetActive(false);
        arthur = GameObject.Find("NPC Arthur");
        lea = GameObject.Find("NPC Léa");
        entrance = GameObject.Find("Entrance");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
                DisplayNextSentence();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);
        nameText.text = dialogue.npcName;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
            sentences.Enqueue(sentence);

        dialogueBox.gameObject.SetActive(true);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            if (nameText.text == "Arthur" && questText.text == "- Parler à Arthur")
            {
                questText.text = "- Éliminer 5 goblins";
                arthur.GetComponent<DialogueTrigger>().dialogue.sentences = new string[1]; 
                arthur.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Complète ma quête ou va voir Léa si c'est déjà fait.";
            }

            if (nameText.text == "Léa" && questText.text == "- Aller voir Léa")
            {
                entrance.GetComponent<DoorOpen>().enabled = true;
                questText.text = "- Entrer dans le donjon";
                lea.GetComponent<DialogueTrigger>().dialogue.sentences = new string[1];
                arthur.GetComponent<DialogueTrigger>().dialogue.sentences = new string[1];
                lea.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Tu dois aller vaincre Kragz au donjon!";
                arthur.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Tu dois aller vaincre Kragz au donjon!";
            }

            EndDialogue();
            return;
        }
        else if (sentences.Count == 1)
            GameObject.Find("Continue Dialogue").GetComponent<Text>().text = "Fermer (C)";
        else
            GameObject.Find("Continue Dialogue").GetComponent<Text>().text = "Continuer (C)";

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
        dialogueBox.gameObject.SetActive(false);
    }
}
