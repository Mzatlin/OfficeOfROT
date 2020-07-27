using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneEventManager : MonoBehaviour, ILoadScene
{

    [SerializeField]
    string sceneName;
    [SerializeField]
    float timeDelay = 2f;
    public event Action OnLevelLoad;

    public void LoadScene() 
    {
        OnLevelLoad?.Invoke();
        StartCoroutine(LoadDelay());
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

}
