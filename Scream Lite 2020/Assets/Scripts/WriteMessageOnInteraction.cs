using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteMessageOnInteraction : MonoBehaviour,IInteractionWrite
{
    [SerializeField]
    DialogProcessorSO dialogueWrite;
    [SerializeField]
    DialogSO dialogueSO;


    IInteract interaction;
    bool isInteracting = false;

    public bool IsInteracting { get => isInteracting; set => isInteracting = value; }


    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<IInteract>();
        if(interaction != null)
        {
            interaction.OnInteract += HandleInteraction;
        }

    }

    private void HandleEnd()
    {
        if (isInteracting)
        {
            isInteracting = false;
            dialogueWrite.OnEnd -= HandleEnd;
        }
    }


    void HandleInteraction()
    {
        dialogueWrite.SetupDialougeWriter(dialogueSO);
        isInteracting = true;
        dialogueWrite.OnEnd += HandleEnd;
    }

}
