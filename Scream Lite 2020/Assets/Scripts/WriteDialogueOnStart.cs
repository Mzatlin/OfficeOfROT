using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteDialogueOnStart : MonoBehaviour
{
    [SerializeField]
    DialogueLoader dialogueWrite;
    [SerializeField]
    DialogSO dialogueSO;


    // Start is called before the first frame update
    void Start()
    {
        dialogueWrite.SetupDialougeWriter(dialogueSO);
        //  StartCoroutine(WriteDelay());

    }

    IEnumerator WriteDelay()
    {
        yield return new WaitForSeconds(2f);
     //   dialogueWrite.SetupDialougeWriter(dialogueSO);
    }

}
