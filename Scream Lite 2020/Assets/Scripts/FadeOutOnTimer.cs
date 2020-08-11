using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutOnTimer : FadeInBase
{
    [SerializeField]
    float delay = 3;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        StartCoroutine(FadeDelay());
    }

    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(delay);
        FadeIn();
    }

    protected override void FadeIn()
    {
        animate.SetBool("IsFadeIn", false);
        animate.SetBool("IsFadeOut", true);
    }
}
