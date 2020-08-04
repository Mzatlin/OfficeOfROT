using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnDialogueEnd : HandleInteractBase, IExitSpawn
{
    public event Action OnSpawnEnd;
    public List<GameObject> spawnObjects = new List<GameObject>();
    public NPCCheckListSO checkList;
    public DialogueLoader dialogueWrite;
    public DialogSO dialogueSO;
    public DialogSO endDialogue;
    bool isFinished;
    ILoadDialogue loader;

    protected override void Awake()
    {
        base.Awake();
        isFinished = false;
        dialogueWrite.OnEnd += HandleEnd;
        SetupObjects();
        loader = GetComponent<ILoadDialogue>();

    }

    void OnDestroy()
    {
        dialogueWrite.OnEnd -= HandleEnd;
    }

    void SetupObjects()
    {
        if(spawnObjects != null && spawnObjects.Capacity > 0)
        {
            foreach (GameObject obj in spawnObjects)
            {
                obj.SetActive(false);
            }
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
        loader.SetDialogue(dialogueSO);
    }

    void WriteSuccessMessage()
    {
       loader.SetDialogue(endDialogue);
    }

    protected override void HandleEnd()
    {
        base.HandleEnd();

        if (isFinished)
        {
            OnSpawnEnd();
            foreach (GameObject obj in spawnObjects)
            {
                obj.SetActive(true);
            }
        }
    }

}
