using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToInteractionPoint : MonoBehaviour, IMoveToInteraction
{
    IInteractionWrite interact;
    IMove move;
    public DialogueLoader dialogueWrite;
    public GameObject player;
    public DialogSO dialogueSO;

    [SerializeField]
    float distanceToObject = 2.6f;

    public void MoveToPoint()
    {
        while (interact.IsInteracting && move.MovePath != null)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > distanceToObject)
            {
                LoadDialogue(dialogueSO);
            }
        }

    }

    public void LoadDialogue(DialogSO dialogue)
    {
        //  if (!isLoaded)
        //  {
        dialogueWrite.SetupDialougeWriter(dialogueSO);
        //   isLoaded = true;
        //   isReady = false;
        //   raycast.CanCast = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<IInteractionWrite>();
        if (player != null)
        {
            move = player.GetComponent<IMove>();
        }
    }
}
