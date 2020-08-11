using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOffNPCOnInteract : HandleInteractBase
{

    public string npcName;
    [SerializeField]
    NPCCheckListSO checkList;

    protected override void HandleInteraction()
    {
        base.HandleInteraction();
        if (checkList.npcList.ContainsKey(npcName))
        {
            checkList.npcList[npcName] = true;
        }
        else
        {
            Debug.Log("Name does not exist in NPC Checklist!");
        }
    }
}
