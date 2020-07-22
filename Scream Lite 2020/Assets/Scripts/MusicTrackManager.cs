using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrackManager : MonoBehaviour
{
    AK.Wwise.Event musicEvent = null;
    // Start is called before the first frame update
    void Start()
    {
        musicEvent.Post(gameObject);
    }

    void OnDestroy()
    {
        musicEvent.Stop(gameObject);
    }


}
