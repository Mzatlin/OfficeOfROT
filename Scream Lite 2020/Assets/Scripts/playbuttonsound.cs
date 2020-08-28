using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playbuttonsound : HandleInteractBase
{
    [SerializeField]
    private AK.Wwise.Event myEvent = null;
    ICameraRaycast raycastCamera;
    Camera cam;
    bool isPlaying = false;

    protected override void Awake()
    {
        base.Awake();
        cam = Camera.main;
        raycastCamera = cam.GetComponent<ICameraRaycast>();
    }

    private void OnDestroy()
    {
        myEvent.Stop(gameObject);
    }

    protected override void HandleInteraction()
    {
        base.HandleInteraction();
        if (raycastCamera != null && raycastCamera.CanCast && !isPlaying)
        {
            StartCoroutine(PlaySoundDelay());
        }
    }
    public void PlayButton()
    {
        myEvent.Post(gameObject);
    }
    IEnumerator PlaySoundDelay()
    {
        isPlaying = true;
        PlayButton();
        yield return new WaitForSeconds(.1f);
        isPlaying = false;
    }


}