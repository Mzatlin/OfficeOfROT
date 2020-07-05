using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOnDialogueExit : MonoBehaviour
{
    public List<GameObject> despawns;
    IExitSpawn spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GetComponent<IExitSpawn>();
        spawn.OnSpawnEnd += HandleSpawn;
    }

    private void HandleSpawn()
    {
        foreach(GameObject obj in despawns)
        {
            obj.SetActive(false);
        }
    }

}
