using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateFadeInOnDialogueExit : FadeInBase
{

    private Animator animate;
    public DialogueLoader load;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        load.OnEnd += HandleEnd;
    }

    private void HandleEnd()
    {
        if (animate != null)
        {
            FadeIn();
        }
    }

    protected override void FadeIn()
    {
        animate.SetBool("IsFadeIn", true);
        animate.SetBool("IsFadeOut", false);
    }
}
