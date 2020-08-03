using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteNPCMessageOnInteraction : HandleInteractBase, INPCWrite
{
    public GameObject player;
    bool isLoaded = false;
    public DialogueLoader dialogueWrite;
    ICameraRaycast raycast;
    Camera cam;
    public DialogSO dialogueSO;
    public DialogSO dialogToLoad { get => dialogueSO; set => dialogueSO = value; }

    protected override void Awake()
    {
        base.Awake();
        dialogueWrite.OnEnd += HandleEnd;
        cam = Camera.main;
        raycast = cam.GetComponent<ICameraRaycast>();
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
       // dialogueWrite.SetupDialougeWriter(dialogueSO);
    }

    void Update()
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

    void LoadDialogue()
    {
        if (!isLoaded)
        {
            dialogueWrite.SetupDialougeWriter(dialogueSO);
            isLoaded = true;
        }

    }

}
