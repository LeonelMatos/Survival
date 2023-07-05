using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> dialogues;
    private Player player;
    private KeyCode interact;

    private DialogueTrigger childDialogue;
    
    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this);
    }

    public void SetDialogue()
    {
        for (int i = 0; i < dialogues.Count; i++)
            if (!dialogues[i].isDone)
            {
                TriggerDialogue(dialogues[i]);
                return;
            }
    }
}
