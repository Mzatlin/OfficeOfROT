using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDialogueProcessor : MonoBehaviour, ILoadDialogue
{
    IInteractionWrite interact;
    IMoveToInteraction moveInteract;
    public GameObject player;
    public DialogueLoader dialogueWrite;
    IMove move;
    ICameraRaycast raycast;
    Camera cam;
    DialogSO dialogueSO;
    bool isLoaded = false;
    public bool IsLoaded { get => isLoaded; set => isLoaded = value; }
    bool isReady = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        interact = GetComponent<IInteractionWrite>();
        raycast = cam.GetComponent<ICameraRaycast>();
        moveInteract = GetComponent<IMoveToInteraction>();

        if(player != null)
        {
            move = player.GetComponent<IMove>();
        }
    }

    void Update()
    {
        if (interact.IsInteracting && isReady && move.MovePath != null)
        {
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
        StartCoroutine(LoadDelay());
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(.2f);
        isReady = true;
    }
    public void LoadDialogue()
    {
        if (!isLoaded)
        {
            dialogueWrite.SetupDialougeWriter(dialogueSO);
            isLoaded = true;
            isReady = false;
            raycast.CanCast = false;
        }

    }
}
