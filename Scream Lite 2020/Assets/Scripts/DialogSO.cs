using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogSO : ScriptableObject
{
    public string name;
    public abstract void LoadNextDialogue();
}
