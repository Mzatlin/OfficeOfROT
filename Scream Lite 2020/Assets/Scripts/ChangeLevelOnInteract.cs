using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelOnInteract : HandleInteractBase
{
    ILoadScene scene;
    ILoadDialogue loader;
    public NPCCheckListSO checkList;
    public DialogSO dialogueSO;


    protected override void Awake()
    {
        base.Awake();
        scene = GetComponent<ILoadScene>();
        loader = GetComponent<ILoadDialogue>();
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
        if (loader != null || dialogueSO != null)
        {
            loader.SetDialogue(dialogueSO);
        }
        else
        {
            Debug.Log("No loader found");
        }
    }

    protected override void HandleEnd()
    {
        base.HandleEnd();
    }
}
