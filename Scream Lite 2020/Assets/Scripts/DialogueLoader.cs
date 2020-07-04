using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName ="DialogueLoader")]
public class DialogueLoader : ScriptableObject
{
    public event Action OnWrite;
    public event Action OnMenuWrite;
    public event Action OnEnd;
    public DialogSO currentDialogue;

    public void SetupDialougeWriter(DialogSO dialogue)
    {
        if (dialogue != null)
        {
            currentDialogue = dialogue;
            DecideWriter();
        }

    }

    public void DecideWriter()
    {
        if (currentDialogue.options.Capacity <= 1)
        {
            OnWrite();
        }
        else
        {
            OnMenuWrite();
        }
    }

    public void EndDialougeWriter()
    {
        OnEnd();
    }
}
