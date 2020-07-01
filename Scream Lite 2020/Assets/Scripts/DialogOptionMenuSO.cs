using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOptionMenuSO : DialogSO, IDialogueOptionMenu
{
    public List<DialogOptionSO> options;
    public string description;
    public string Description => description;

}
