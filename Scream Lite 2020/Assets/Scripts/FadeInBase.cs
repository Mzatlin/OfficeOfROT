using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class FadeInBase : MonoBehaviour
{
    [SerializeField]
    protected Image image;
    protected Animator animate;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (image != null) 
        {
            animate = image.GetComponent<Animator>();
        }  
    }

    protected abstract void FadeIn();
}


