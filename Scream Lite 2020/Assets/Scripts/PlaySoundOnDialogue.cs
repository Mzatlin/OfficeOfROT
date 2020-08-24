using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnDialogue : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event myEvent = null;
    public DialogueLoader dialogueWrite;
    IInteractionWrite interact;
    // Start is called before the first frame update
    void Start()
    {
        if (dialogueWrite != null)
        {
            dialogueWrite.OnWrite += HandleWrite;
        }
        interact = GetComponent<IInteractionWrite>();
    }

    void OnDestroy()
    {
        dialogueWrite.OnWrite -= HandleWrite;
        myEvent.Stop(gameObject);
    }

    void HandleWrite()
    {
        if(interact != null && interact.IsInteracting)
        {
            myEvent.Post(gameObject);
        }
    }
}
