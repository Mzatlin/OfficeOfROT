using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOffNPCOnInteract : HandleInteractBase
{

    public string name;
    [SerializeField]
    NPCCheckListSO checkList;

    protected override void HandleInteraction()
    {
        base.HandleInteraction();
        if (checkList.npcList.ContainsKey(name))
        {
            checkList.npcList[name] = true;
        }
        else
        {
            Debug.Log("Name does not exist in NPC Checklist!");
        }
    }
}
