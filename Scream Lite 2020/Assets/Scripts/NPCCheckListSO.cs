using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="NPC List")]
public class NPCCheckListSO : ScriptableObject
{
    public Dictionary<string, bool> npcList = new Dictionary<string, bool>();

    public bool GetNPCCheck(string name)
    {
        if (npcList.ContainsKey(name))
        {
            return npcList[name];
        }
        else
        {
            return false;
        }
    }

}
