using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRaycastOnDialogueEnd : MonoBehaviour
{
    public DialogueLoader loader;
    ICameraRaycast raycast;


    // Start is called before the first frame update
    void Start()
    {
        loader.OnEnd += HandleEnd;
        raycast = GetComponent<ICameraRaycast>();
        if (raycast != null)
        {
            raycast.CanCast = false;
        }
    }

    private void OnDestroy()
    {
        loader.OnEnd -= HandleEnd;
    }

    private void HandleEnd()
    {
        raycast.CanCast = true;
    }


}
