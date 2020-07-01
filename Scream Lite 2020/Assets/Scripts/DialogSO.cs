using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueObject")]
public class DialogSO : ScriptableObject
{
    public string name;
    [TextArea(2, 8)]
    public string[] sentences;
    public List<DialogOptionSO> options; 
}
