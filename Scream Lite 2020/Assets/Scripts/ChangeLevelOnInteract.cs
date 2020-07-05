using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelOnInteract : HandleInteractBase
{
    [SerializeField]
    string sceneName;
    public NPCCheckListSO checkList;
    public DialogueLoader dialogueWrite;
    public DialogSO dialogueSO;

    protected override void Awake()
    {
        base.Awake();
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

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
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
