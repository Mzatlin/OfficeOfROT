using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDialogueProcessor : MonoBehaviour, ILoadDialogue
{
    IInteractionWrite interact;
    public GameObject player;
    public DialogueLoader dialogueWrite;
    IMove move;
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

        if(player != null)
        {
            move = player.GetComponent<IMove>();
        }
    }

    void Update()
    {
        if (interact.IsInteracting && isReady && move.MovePath != null)
        {
            raycast.CanCast = false;// StartCoroutine(Delay());
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
    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(.2f);
        raycast.CanCast = false;
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
