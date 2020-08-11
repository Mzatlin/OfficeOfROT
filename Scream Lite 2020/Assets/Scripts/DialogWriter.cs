using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogWriter : WriterBase
{
    public Queue<string> dialogueSentences;
    private string currentSentence;
    private string name1;
    private string name2;
    IEnumerator coroutine = null;
    bool canSwap = false;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        dialogCanvas.enabled = false;
        dialogueSentences = new Queue<string>();
        dialogue.OnWrite += HandleWrite;
    }


    void HandleWrite()
    {
        textName.text = dialogue.currentDialogue.name1;
        if(dialogue.currentDialogue.name2 != "")
        {
            canSwap = true;
        }
        if(dialogCanvas != null)
        {
            dialogCanvas.enabled = true;
        }

        dialogueSentences.Clear();
        foreach (string line in dialogue.currentDialogue.sentences)
        {
            dialogueSentences.Enqueue(line);
        }
        WriteDialogue();
    }

    public void ProcessDialogWrite()
    {
        if(currentSentence != textDialog.text)
        {
            textDialog.text = currentSentence;
            StopCoroutine(coroutine);
            return;
        }
        WriteDialogue();
    }

    protected override void WriteDialogue()
    {

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

        if (this != null)
        {
            base.WriteDialogue();
            StopAllCoroutines();
            currentSentence = dialogueSentences.Dequeue();
            coroutine = TypeLine(currentSentence);
            StartCoroutine(coroutine);
        }


        if (canSwap)
        {
            NameSwap(textName.text);
        } 
    }

    void NameSwap(string name)
    {
        if (name == dialogue.currentDialogue.name1)
        {
           textName.text = dialogue.currentDialogue.name2;
        }
        else
        {
            textName.text = dialogue.currentDialogue.name1;
        }
    }
}
