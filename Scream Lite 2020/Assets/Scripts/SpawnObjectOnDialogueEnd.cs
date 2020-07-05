using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnDialogueEnd : HandleInteractBase
{

    public List<GameObject> spawnObjects = new List<GameObject>();
    public DialogueLoader dialogue;
    IInteractionWrite interact;
    bool isFinished;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in spawnObjects)
        {
            obj.SetActive(false);
        }

        interact = GetComponent<IInteractionWrite>();
        dialogue.OnEnd += HandleEnd;
        dialogue.OnWrite += HandleInteraction;
    }

    protected override void HandleInteraction()
    {
        base.HandleInteraction();
    }

    protected override void HandleEnd()
    {

   //     if (interact.IsInteracting)
   //     {
            foreach (GameObject obj in spawnObjects)
            {
                obj.SetActive(true);
            }
   //     }
        base.HandleEnd();


    }

}
