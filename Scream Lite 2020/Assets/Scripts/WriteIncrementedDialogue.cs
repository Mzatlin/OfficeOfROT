using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteIncrementedDialogue : HandleInteractBase
{
    public DialogProcessorSO dialogueWrite;
    public List<DialogSO> dialogueSO;
    int index =0;

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
        if(index <= dialogueSO.Capacity-1)
        {
            dialogueWrite.SetupDialougeWriter(dialogueSO[index]);
            index++;
        }
        else
        {
            index = 0;
        }

    }

}
