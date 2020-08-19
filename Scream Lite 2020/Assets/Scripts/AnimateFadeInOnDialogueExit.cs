using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateFadeInOnDialogueExit : FadeInBase
{
    public DialogueLoader load;
    [SerializeField]
    bool fadeSwapper = false;
    [SerializeField]
    float timeDelay = 0;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        load.OnEnd += HandleEnd;
    }

    private void OnDestroy()
    {
        load.OnEnd -= HandleEnd;
    }

    private void HandleEnd()
    {
        if (animate != null)
        {
            StartCoroutine(Fadedelay());
        }
    }

    IEnumerator Fadedelay()
    {
        yield return new WaitForSeconds(timeDelay);
        FadeIn();
    }


    protected override void FadeIn()
    {

        animate.SetBool("IsFadeIn", fadeSwapper);
        animate.SetBool("IsFadeOut", !fadeSwapper);
    }
}
