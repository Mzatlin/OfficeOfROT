using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteMessageOnInteraction : HandleInteractBase
{
    public DialogueLoader dialogueWrite;
    public DialogSO dialogueSO;

    protected override void Awake()
    {
        base.Awake();
        dialogueWrite.OnEnd += HandleEnd;
    }
    protected override void HandleEnd()
    {
        base.HandleEnd();
        if (IsInteracting)
        {
            dialogueWrite.OnEnd -= HandleEnd;
        }

    }
    protected override void HandleInteraction()
    {
        base.HandleInteraction();
        dialogueWrite.SetupDialougeWriter(dialogueSO);
    }

}
