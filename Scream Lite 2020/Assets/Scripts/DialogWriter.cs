using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogWriter : WriterBase
{
    [SerializeField]
    TextMeshProUGUI textName;
    public Queue<string> dialogueSentences;
    [SerializeField]
    DialogProcessorSO dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogCanvas.enabled = false;
        dialogueSentences = new Queue<string>();
        dialogue.OnWrite += HandleWrite;
    }

    void HandleWrite()
    {
        textName.text = dialogue.currentDialogue.name;
        dialogCanvas.enabled = true;
        dialogueSentences.Clear();
        foreach (string line in dialogue.currentDialogue.sentences)
        {
            dialogueSentences.Enqueue(line);
        }
        WriteDialogue();
    }

    protected override void WriteDialogue()
    {
        base.WriteDialogue();
        if (dialogueSentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        StartCoroutine(TypeLine(dialogueSentences.Dequeue()));
        NameSwap(textName.text);
    }

    void NameSwap(string name)
    {
        if (name == dialogue.currentDialogue.name)
        {
            textName.text = dialogue.currentDialogue.name2;
        }
        else
        {
            textName.text = dialogue.currentDialogue.name;
        }
    }

    void EndDialogue()
    {
        Debug.Log("Dialog Ended");
        dialogCanvas.enabled = false;
        dialogue.EndDialougeWriter();
    }
}
