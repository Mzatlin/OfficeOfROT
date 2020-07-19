using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnDialogEnd : MonoBehaviour
{
    [SerializeField]
    float timeDelay = 3f;
    public string name;
    public DialogueLoader load; 
    // Start is called before the first frame update
    void Start()
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
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

}
