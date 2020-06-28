using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogWriter : MonoBehaviour
{
    [SerializeField]
    float typeSpeed = .3f;
    [SerializeField]
    TextMeshProUGUI textName;
    [SerializeField]
    TextMeshProUGUI textDialog;
    [SerializeField]
    Canvas canvas;
    public Queue<string> dialogueSentences;
    [SerializeField]
    DialogueSO dialogue;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
        dialogueSentences = new Queue<string>();
        dialogue.OnWrite += HandleWrite;
    }

    void HandleWrite()
    {
        textName.text = dialogue.currentDialogue.name;
        canvas.enabled = true;
        dialogueSentences.Clear();
        foreach (string line in dialogue.currentDialogue.sentences)
        {
            dialogueSentences.Enqueue(line);
        }
        WriteDialog();
    }

    public void WriteDialog()
    {
        if(dialogueSentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        StopAllCoroutines();
        textDialog.text = "";
        StartCoroutine(TypeLine(dialogueSentences.Dequeue()));
    }

    IEnumerator TypeLine(string line)
    {
        foreach(char letter in line)
        {
            textDialog.text += letter;
            yield return new WaitForSeconds(typeSpeed * Time.deltaTime);
        }

    }

    void EndDialogue()
    {
        Debug.Log("Dialog Ended");
        canvas.enabled = false;
        dialogue.EndDialougeWriter();
    }
}
