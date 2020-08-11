using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnDialogEnd : DayLookupBase
{
    [SerializeField]
    float timeDelay = 3f;
    public List<string> names = new List<string>();
    private string name;
    public DialogueLoader load; 
    // Start is called before the first frame update
    protected override void Start()
    {
        load.OnEnd += HandleEnd;
    }

    private void OnDestroy()
    {
        load.OnEnd -= HandleEnd;
    }

    private void HandleEnd()
    {
        StartCoroutine(LoadDelay());
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(timeDelay);
        LookupItem(day.currentDay);
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    protected override void SetItem(int index)
    {
        if (names.Capacity > 1 && names[index - 1] != null)
        {
            name = names[index - 1];
        }
        else
        {
            name = names[0];
        }
    }
}
