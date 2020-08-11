using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueObject")]
public class DialogSO : ScriptableObject
{
    public string name1;
    public string name2;
    [TextArea(2, 8)]
    public string[] sentences;
    public List<DialogOptionSO> options; 
}
