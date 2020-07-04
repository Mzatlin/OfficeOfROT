using System;
interface IInteract
{
    event Action OnInteract;
    void ProcessInteraction();
}
