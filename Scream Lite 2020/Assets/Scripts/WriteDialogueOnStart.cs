using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteDialogueOnStart : MonoBehaviour
{
    [SerializeField]
    DialogProcessorSO dialogueWrite;
    [SerializeField]
    DialogSO dialogueSO;


    // Start is called before the first frame update
    void Start()
    {
        dialogueWrite.SetupDialougeWriter(dialogueSO);
    }

}
