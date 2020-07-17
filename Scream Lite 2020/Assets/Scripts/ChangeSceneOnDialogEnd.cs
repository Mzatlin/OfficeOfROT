using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnDialogEnd : MonoBehaviour
{
    public string name;
    public DialogueLoader load; 
    // Start is called before the first frame update
    void Start()
    {
        load.OnEnd += HandleEnd;
    }

    private void HandleEnd()
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

}
