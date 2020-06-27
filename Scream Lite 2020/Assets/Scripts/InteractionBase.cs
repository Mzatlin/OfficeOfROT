using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour, IInteract
{
    public event Action OnInteract;

    public void ProcessInteraction()
    {
        OnInteract?.Invoke();
    }

}
