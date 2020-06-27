using System;
internal interface IInteract
{
    event Action OnInteract;
    void ProcessInteraction();
}