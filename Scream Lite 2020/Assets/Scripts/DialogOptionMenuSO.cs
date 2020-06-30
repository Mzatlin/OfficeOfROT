using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOptionMenuSO : DialogSO, IDialogueOptionMenu
{
    public List<DialogOptionSO> options;
    public string description;
    public string Description => description;

    public override void LoadNextDialogue()
    {
        throw new System.NotImplementedException();
    }
}
