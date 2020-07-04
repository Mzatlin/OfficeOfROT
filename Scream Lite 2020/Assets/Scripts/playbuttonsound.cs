using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playbuttonsound : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event myEvent = null;

    public void OnClick()
    {
        myEvent.Post(gameObject);

    }

}