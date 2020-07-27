using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOutOnLevelLoad : MonoBehaviour
{

    [SerializeField]
    Image image;
    Animator animate;
    ILoadScene scene;

    // Start is called before the first frame update
    void Start()
    {
        if (image != null)
        {
            animate = image.GetComponent<Animator>();
        }

        scene = GetComponent<ILoadScene>();
        if(scene != null)
        {
            scene.OnLevelLoad += HandleLoad;
        }

    }

    void OnDestroy()
    {
        scene.OnLevelLoad -= HandleLoad;
    }

    void HandleLoad()
    {
        AnimateFade();
    }

    public void AnimateFade()
    {

        animate.SetBool("IsFadeOut", true);
        animate.SetBool("IsFadeIn", false);
    }




}
