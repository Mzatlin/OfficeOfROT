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
        if (spawn != null)
        {
            spawn.OnSpawnEnd += HandleSpawn;
        }
    }

    private void HandleSpawn()
    {
        if (despawns != null && despawns.Capacity > 0)
        {
            foreach (GameObject obj in despawns)
            {
                obj.SetActive(false);
            }
        }
    }

}
