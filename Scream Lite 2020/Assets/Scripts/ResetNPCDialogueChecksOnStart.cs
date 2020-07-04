using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetNPCDialogueChecksOnStart : MonoBehaviour
{
    [SerializeField]
    NPCCheckListSO checkList;
    public List<string> npcs = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        ResetCheckList();
    }

    void ResetCheckList()
    {
        foreach(string npc in npcs)
        {
            if (!checkList.npcList.ContainsKey(npc))
            {
                checkList.npcList.Add(npc, false);
            }
            else
            {
                checkList.npcList[npc] = false;
            }
        }
    }

}
