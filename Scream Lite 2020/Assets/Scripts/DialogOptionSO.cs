using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialogue/DialougeOption")]
public class DialogOptionSO : ScriptableObject
{
    [TextArea(2,9)]
    public string description;
    public DialogSO dialogue;
}
