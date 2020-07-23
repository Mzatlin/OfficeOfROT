using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOutOnLevelLoad : MonoBehaviour, ILoadScene
{
    [SerializeField]
    Image image;
    Animator animate;
    [SerializeField]
    string sceneName;
    [SerializeField]
    float timeDelay = 2f;
    ICameraRaycast raycast;
    Camera cam;
    public void LoadScene()
    {
        raycast.CanCast = false;
        animate.SetBool("IsFadeOut", true);
        animate.SetBool("IsFadeIn", false);
        StartCoroutine(LoadDelay());

    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        raycast = cam.GetComponent<ICameraRaycast>();
        if(image != null)
        {
            animate = image.GetComponent<Animator>();
        }
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

}
