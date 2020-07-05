using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnDialogueEnd : HandleInteractBase
{
    public List<GameObject> spawnObjects = new List<GameObject>();
    public NPCCheckListSO checkList;
    public DialogueLoader dialogueWrite;
    public DialogSO dialogueSO;
    public DialogSO endDialogue;
    bool isFinished;

    protected override void Awake()
    {
        base.Awake();
        isFinished = false;
        dialogueWrite.OnEnd += HandleEnd;
        foreach (GameObject obj in spawnObjects)
        {
            obj.SetActive(false);
        }
    }
    protected override void HandleInteraction()
    {
        base.HandleInteraction();

        foreach (string npc in checkList.npcList.Keys)
        {
            if (!checkList.GetNPCCheck(npc))
            {
                WriteFailureMessage();
                return;
            }
        }
        isFinished = true;
        WriteSuccessMessage();
        
    }

    void WriteFailureMessage()
    {
        dialogueWrite.SetupDialougeWriter(dialogueSO);
    }

    void WriteSuccessMessage()
    {
        dialogueWrite.SetupDialougeWriter(endDialogue);
    }

    protected override void HandleEnd()
    {
        base.HandleEnd();

        if (isFinished)
        {
            foreach (GameObject obj in spawnObjects)
            {
                obj.SetActive(true);
            }
        }
    }

}
