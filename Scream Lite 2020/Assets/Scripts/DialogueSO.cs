using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(menuName = "Dialouge")]
public class DialogueSO : ScriptableObject
{
    public event Action OnWrite;
    public event Action OnEnd;
    public DialogueObject currentDialogue;

    public void SetupDialougeWriter(DialogueObject dialogue)
    {
        if (dialogue != null)
        {
            currentDialogue = dialogue;
            OnWrite();
        }

    }

    public void EndDialougeWriter()
    {
        OnEnd();
    }
}
