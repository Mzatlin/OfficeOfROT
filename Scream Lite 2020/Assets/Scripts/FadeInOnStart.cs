using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOnStart : FadeInBase
{
    [SerializeField]
    bool fadeSwapper = true;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        FadeIn();
    }

    protected override void FadeIn()
    {
        animate.SetBool("IsFadeIn", fadeSwapper);
        animate.SetBool("IsFadeOut", !fadeSwapper);
    }

}
