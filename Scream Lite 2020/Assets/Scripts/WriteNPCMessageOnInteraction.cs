using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteNPCMessageOnInteraction : HandleInteractBase, INPCWrite
{
    ILoadDialogue loader;
    bool isLoaded = false;
    public DialogueLoader dialogueWrite;
    ICameraRaycast raycast;
    Camera cam;
    public DialogSO dialogueSO;
    public DialogSO dialogToLoad { get => dialogueSO; set => dialogueSO = value; }

    public bool IsLoaded { get => isLoaded; set => isLoaded = value; }

    protected override void Awake()
    {
        base.Awake();
        dialogueWrite.OnEnd += HandleEnd;
        cam = Camera.main;
        raycast = cam.GetComponent<ICameraRaycast>();
        loader = GetComponent<ILoadDialogue>();
    }
    protected override void HandleEnd()
    {
        base.HandleEnd();
        isLoaded = false;
        if (IsInteracting)
        {
            dialogueWrite.OnEnd -= HandleEnd;
        }

    }
    protected override void HandleInteraction()
    {
        base.HandleInteraction();
        loader.SetDialogue(dialogueSO);
    }

 /*   void Update()
    {
        if (IsInteracting)
        {
            raycast.CanCast = false;
            if (Vector2.Distance(transform.position, player.transform.position) < 2.5)
            {
                LoadDialogue();
            }

        }
    }

   public void LoadDialogue()
    {
        if (!isLoaded)
        {
            dialogueWrite.SetupDialougeWriter(dialogueSO);
            isLoaded = true;
        }

    }
    */

}
