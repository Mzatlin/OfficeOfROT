using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogWriter : WriterBase
{
    public Queue<string> dialogueSentences;
    private string name1;
    private string name2;
    bool canSwap = false;
    // Start is called before the first frame update
    void Awake()
    {
        dialogCanvas.enabled = false;
        dialogueSentences = new Queue<string>();
        dialogue.OnWrite += HandleWrite;
    }


    void HandleWrite()
    {
        textName.text = dialogue.currentDialogue.name;
        if(dialogue.currentDialogue.name2 != "")
        {
            canSwap = true;
        }
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
            if (dialogue.currentDialogue.options.Capacity > 0)
            {
                dialogue.SetupDialougeWriter(dialogue.currentDialogue.options[0].dialogue);
                return;
            }
            EndDialogue();
            return;
        }
        StartCoroutine(TypeLine(dialogueSentences.Dequeue()));

        if (canSwap)
        {
            NameSwap(textName.text);
        } 
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
}
