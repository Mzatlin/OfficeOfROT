using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playbuttonsound : HandleInteractBase
{
    [SerializeField]
    private AK.Wwise.Event myEvent = null;
    ICameraRaycast camera;
    Camera cam;

    protected override void Awake()
    {
        base.Awake();
        cam = Camera.main;
        camera = cam.GetComponent<ICameraRaycast>();
    }

    private void OnDestroy()
    {
        myEvent.Stop(gameObject);
    }

    protected override void HandleInteraction()
    {
        myEvent.Post(gameObject);
        base.HandleInteraction();
        if (camera != null && camera.CanCast)
        {
            myEvent.Post(gameObject);
        }
    }


}