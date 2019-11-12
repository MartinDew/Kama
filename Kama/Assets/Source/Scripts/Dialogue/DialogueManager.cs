using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public float radius = 20f;
    public Text nameText;
    public Text dialogueText;
    public Image dialogueBox;
    //public Animator animator;
    private float distance;
    private Queue<string> sentences;
    private void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.gameObject.SetActive(false);
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
