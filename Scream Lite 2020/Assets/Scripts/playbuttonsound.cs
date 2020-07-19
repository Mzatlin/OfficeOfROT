using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playbuttonsound : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event myEvent = null;
    ICameraRaycast camera;
    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        camera = cam.GetComponent<ICameraRaycast>();
    }

    public void OnClick()
    {
  
        if (camera != null && camera.CanCast)
        {
            myEvent.Post(gameObject);
        }


    }

}