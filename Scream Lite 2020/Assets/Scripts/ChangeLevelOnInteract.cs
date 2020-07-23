using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelOnInteract : HandleInteractBase
{
    ILoadScene scene;
    public NPCCheckListSO checkList;
    public DialogueLoader dialogueWrite;
    public DialogSO dialogueSO;

    protected override void Awake()
    {
        base.Awake();
        scene = GetComponent<ILoadScene>();
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
        scene.LoadScene();
     
    }

    void WriteFailureMessage()
    {
        dialogueWrite.SetupDialougeWriter(dialogueSO);
    }

    protected override void HandleEnd()
    {
        base.HandleEnd();
    }
}
