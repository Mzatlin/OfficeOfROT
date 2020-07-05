using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnHit : MonoBehaviour
{
    [SerializeField]
    LayerMask targetMask;
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & targetMask) != 0)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

}
