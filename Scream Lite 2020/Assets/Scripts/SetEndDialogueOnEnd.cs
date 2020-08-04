using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This class takes a list of options and chooses a dialogue response based on the selected option.
 * When the user selects an option, it will remain cached in the DialogueSO, so on completion we can find the selected option and set it. 
 * This option is then set to the attached NPC class for it to output the correct final dialogue box when reinitiated.
 */
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
