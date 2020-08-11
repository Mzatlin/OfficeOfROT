using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterTimer : MonoBehaviour
{
    [SerializeField]
    float timer = 5f;
    [SerializeField]
    string sceneName = "";
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
    }
}
