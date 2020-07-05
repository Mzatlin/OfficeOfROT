using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteNPCMessageOnInteraction : HandleInteractBase, INPCWrite
{
    public DialogueLoader dialogueWrite;
    public DialogSO dialogueSO;
    public DialogSO dialogToLoad { get => dialogueSO; set => dialogueSO = value; }

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
