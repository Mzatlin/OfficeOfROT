﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueObject 
{
    public string name;
    public string name2;
    [TextArea(2,8)]
    public string[] sentences;

}
