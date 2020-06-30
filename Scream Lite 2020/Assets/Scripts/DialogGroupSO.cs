using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogGroupSO : DialogSO, IDialogGroup
{ 

    public string name2;

    [TextArea(2, 8)]
    public string[] sentences;
    public string[] Sentences => sentences;

    public DialogSO dialogue;

  

    public override void LoadNextDialogue()
    {
        throw new System.NotImplementedException();
    }

}
