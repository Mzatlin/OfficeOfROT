using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnClick : MonoBehaviour
{

    public AK.Wwise.Event MyEvent = null;

    private void OnMouseDown()
    {
        MyEvent.Post(gameObject); 
    }
}   

 
