using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteDialogueOnStart : MonoBehaviour, IStartWrite
{
    [SerializeField]
    DialogueLoader dialogueWrite;
    [SerializeField]
    List<DialogSO> dialogueSOs = new List<DialogSO>();
    [SerializeField]
    float timerDelay = 0.5f;
    int index;

    public void StartWriteDialogue()
    {
       StartCoroutine(WriteDelay());
    }

    IEnumerator WriteDelay()
    {
        yield return new WaitForSeconds(timerDelay);
        if (dialogueSOs.Capacity > 0)
        {
            if (index > dialogueSOs.Capacity - 1)
            {
                index = 0;
            }
            dialogueWrite.SetupDialougeWriter(dialogueSOs[index]);
            index++;
        }
    }
}

