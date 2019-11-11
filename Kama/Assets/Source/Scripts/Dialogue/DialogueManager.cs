using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public float radius = 10f;
    public Button startDialogue;
    public Image dialogueBox;
    private float distance;
    private Queue<string> sentences;
    Transform target;

    //public Animator animator;

    private void Start()
    {
        sentences = new Queue<string>();
        startDialogue.gameObject.SetActive(false);
        dialogueBox.gameObject.SetActive(false);
    }
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Main Character").transform;
    }
    private void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if (distance <= radius)
            startDialogue.gameObject.SetActive(true);
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);

        nameText.text = dialogue.npcName;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
            sentences.Enqueue(sentence);

        dialogueBox.gameObject.SetActive(true);
        startDialogue.gameObject.SetActive(false);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            // make the "continue" button become "end"
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
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
        if (distance <= radius)
            startDialogue.gameObject.SetActive(true);
    }
}
