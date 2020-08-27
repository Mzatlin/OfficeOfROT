using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnLoad : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event myEvent = null;
    ILoadScene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = GetComponent<ILoadScene>();
        if (scene != null)
        {
            scene.OnLevelLoad += HandleLoad;
        }
    }

    void OnDestroy()
    {
        scene.OnLevelLoad -= HandleLoad;
        myEvent.Stop(gameObject);
    }

    private void HandleLoad()
    {
            myEvent.Post(gameObject);
    }

}
