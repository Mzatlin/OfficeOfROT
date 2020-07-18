using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BeginDialogueObjectOnStart : MonoBehaviour
{
    IStartWrite write;
    [SerializeField]
    WriteDialogueOnStart messageManager;
    // Start is called before the first frame update
    void Start()
    {
        messageManager = FindObjectOfType<WriteDialogueOnStart>();
        if(messageManager != null)
        {
            write = messageManager.GetComponent<IStartWrite>();
        }
        if(write != null)
        {
            write.StartWriteDialogue();
        }
    }
}
