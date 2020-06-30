using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnDialogueEnd : MonoBehaviour
{
    [SerializeField]
    GameObject spawnObject;
    [SerializeField]
    DialogProcessorSO dialogue;
    IInteractionWrite interact;
    // Start is called before the first frame update
    void Start()
    {
        spawnObject.SetActive(false);
        interact = GetComponent<IInteractionWrite>();
        dialogue.OnEnd += HandleEnd;
    }

    private void HandleEnd()
    {
        if (interact.isInteracting)
        {
            spawnObject.SetActive(true);
        }
    }

}
