using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> senteces;

    public bool IsRunning = false;
    private DialogueTrigger dialogueTrigger;

    private Dialogue definedDialogue;

    public bool OnDialogue;

    void Start()
    {
        senteces = new Queue<string>();
        dialogueBox.SetActive(true);
    }

    public void StartDialogue(Dialogue dialogue, DialogueTrigger trigger)
    {
        OnDialogue = true;
        dialogueTrigger = trigger;
        definedDialogue = dialogue;
        animator.SetBool("IsOpen", true);
        IsRunning = animator.GetBool("IsOpen");
        //Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        senteces.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            senteces.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (senteces.Count == 0)
        {
            EndDialogue();
            definedDialogue.isDone = true;
            dialogueTrigger.GetComponent<DialogueTrigger>().SetDialogue();
            //return;
        }

        string sentence = senteces.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        IsRunning = false;
        OnDialogue = false;
    }
}
