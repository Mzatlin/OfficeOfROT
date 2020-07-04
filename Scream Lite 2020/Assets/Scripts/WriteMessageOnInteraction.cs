using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteMessageOnInteraction : HandleInteractBase
{
    [SerializeField]
    protected DialogProcessorSO dialogueWrite;
    [SerializeField]
    protected DialogSO dialogueSO;

    protected override void Start()
    {
        base.Start();
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
