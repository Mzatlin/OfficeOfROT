using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogWriter : MonoBehaviour
{
    public Queue<string> dialogueSentences;
    [SerializeField]
    DialogueSO dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogueSentences = new Queue<string>();
        dialogue.OnWrite += HandleWrite;
    }

    void HandleWrite()
    {
        foreach (string line in dialogue.currentDialogue.sentences)
        {
            dialogueSentences.Enqueue(line);
        }

        while (dialogueSentences.Count > 0)
        {
            Debug.Log(dialogueSentences.Dequeue());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
