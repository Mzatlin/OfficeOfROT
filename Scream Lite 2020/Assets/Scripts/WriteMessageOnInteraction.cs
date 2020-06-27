using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteMessageOnInteraction : MonoBehaviour
{
    [SerializeField]
    DialogueSO dialogWrite;
    [SerializeField]
    DialogueObject dialogue;
    IInteract interaction;
    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<IInteract>();
        if(interaction != null)
        {
            interaction.OnInteract += HandleInteraction;
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
        dialogWrite.SetupDialougeWriter(dialogue);
    }

}
