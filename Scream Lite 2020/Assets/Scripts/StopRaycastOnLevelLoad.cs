using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRaycastOnLevelLoad : MonoBehaviour
{
    ILoadScene scene;
    ICameraRaycast raycast;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        scene = GetComponent<ILoadScene>();
        if (scene != null)
        {
            scene.OnLevelLoad += HandleLoad;
        }
        cam = Camera.main;
        raycast = cam.GetComponent<ICameraRaycast>();
    }

    void OnDestroy()
    {
        if (scene != null)
        {
            scene.OnLevelLoad -= HandleLoad;
        }
    }

    private void HandleLoad()
    {
        StartCoroutine(CastDelay());
    }

    IEnumerator CastDelay()
    {
        yield return new WaitForSeconds(.1f);
        raycast.CanCast = false;
    }
}
