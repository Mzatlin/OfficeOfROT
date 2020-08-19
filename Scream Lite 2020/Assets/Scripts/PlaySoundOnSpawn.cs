using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnSpawn : MonoBehaviour
{
    public AK.Wwise.Event MyEvent = null;
    IExitSpawn spawn;
    bool isPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GetComponent<IExitSpawn>();
        spawn.OnSpawnEnd += HandleSpawn;
    }

    private void HandleSpawn()
    {
        if (!isPlayed)
        {
            MyEvent.Post(gameObject);
            isPlayed = true;
        }

    }
}
