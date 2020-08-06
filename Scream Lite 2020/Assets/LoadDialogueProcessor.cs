using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDialogueProcessor : MonoBehaviour, ILoadDialogue
{
    IInteractionWrite interact;
    public GameObject player;
    public DialogueLoader dialogueWrite;
    ICameraRaycast raycast;
    Camera cam;
    public DialogSO dialogueSO;
    bool isLoaded = false;
    public bool IsLoaded { get => isLoaded; set => isLoaded = value; }
    bool isReady = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        interact = GetComponent<IInteractionWrite>();
        raycast = cam.GetComponent<ICameraRaycast>();
    }

    void Update()
    {
        if (interact.IsInteracting && isReady)
        {
            raycast.CanCast = false;
            if (Vector2.Distance(transform.position, player.transform.position) < 2.6)
            {
                LoadDialogue();
            }

        }
        else
        {
            isLoaded = false;
        }
    }
    public void SetDialogue(DialogSO _dialogue)
    {
        dialogueSO = _dialogue;
        isReady = true;
    }
    public void LoadDialogue()
    {
        if (!isLoaded)
        {
            dialogueWrite.SetupDialougeWriter(dialogueSO);
            isLoaded = true;
            raycast.CanCast = false;
            isReady = false;
        }

    }
}
