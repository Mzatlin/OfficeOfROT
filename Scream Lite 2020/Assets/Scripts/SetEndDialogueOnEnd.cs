using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEndDialogueOnEnd : MonoBehaviour
{
    INPCWrite npcDialog;
    public List<DialogSO> endOptions = new List<DialogSO>();
    public List<DialogSO> responses = new List<DialogSO>();
    public DialogueLoader writer;
    // Start is called before the first frame update
    void Start()
    {
        npcDialog = GetComponent<INPCWrite>();
        writer.OnEnd += HandleEnd;
    }

    private void HandleEnd()
    {
        for(int i = 0; i<endOptions.Capacity; i++)
        {
            if (writer.currentDialogue == responses[i])
            {
                npcDialog.dialogToLoad = endOptions[i];
            }
        }
    }

}
