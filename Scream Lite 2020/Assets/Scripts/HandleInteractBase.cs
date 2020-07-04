using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInteractBase : MonoBehaviour, IInteractionWrite
{

    private IInteract interaction;
    protected bool isInteracting = false;

    public bool IsInteracting { get => isInteracting; set => isInteracting = value; }


    // Start is called before the first frame update
    protected virtual void Awake()
    {
        interaction = GetComponent<IInteract>();
        if (interaction != null)
        {
            interaction.OnInteract += HandleInteraction;
        }

    }

    protected virtual void HandleInteraction()
    {
        isInteracting = true;
    }

    protected virtual void HandleEnd()
    {
        if (isInteracting)
        {
            isInteracting = false;
        }
    }
}
