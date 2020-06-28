using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteMessageOnInteraction : MonoBehaviour,IInteractionWrite
{
    [SerializeField]
    DialogueSO dialogueWrite;
    [SerializeField]
    DialogueObject dialogue;
    IInteract interaction;
    bool isInteracting = false;

    bool IInteractionWrite.isInteracting { get => isInteracting; set => isInteracting = value; }

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

    /*   void OnDestroy()
       {
           if(interaction != null)
           {
               interaction.OnInteract -= HandleInteraction;
           }
       }*/

    void HandleInteraction()
    {
        dialogueWrite.SetupDialougeWriter(dialogue);
        isInteracting = true;
        dialogueWrite.OnEnd += HandleEnd;
    }

}
