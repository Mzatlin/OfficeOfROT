using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnClick : MonoBehaviour
{
    public string sceneName;
    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
