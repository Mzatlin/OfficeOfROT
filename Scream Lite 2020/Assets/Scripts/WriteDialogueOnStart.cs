using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteDialogueOnStart : CollectionProcessorBase, IStartWrite
{
    [SerializeField]
    DialogueLoader dialogueWrite;
    [SerializeField]
    List<DialogSO> dialogueSOs = new List<DialogSO>();
    [SerializeField]
    float timerDelay = 0.5f;


    public void StartWriteDialogue()
    {
       StartCoroutine(WriteDelay());
    }

    IEnumerator WriteDelay()
    {
        yield return new WaitForSeconds(timerDelay);
        IterateListByOne(dialogueSOs);
    }

    protected override void UseItemInList(int index)
    {
        dialogueWrite.SetupDialougeWriter(dialogueSOs[index]);
    }
}

