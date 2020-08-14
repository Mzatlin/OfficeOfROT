using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOnExit : MonoBehaviour
{
    public List<GameObject> animateObj = new List<GameObject>();
    private List<Animator> animations = new List<Animator>();
    IExitSpawn spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GetComponent<IExitSpawn>();
        spawn.OnSpawnEnd += HandleSpawn;
        SetupAnimators();
    }

   void SetupAnimators()
    {
        foreach(GameObject obj in animateObj)
        {
            animations.Add(obj.GetComponentInChildren<Animator>());
        }
    }
    private void HandleSpawn()
    {
        foreach (Animator animate in animations)
        {
            animate.SetBool("OnExit", true);
        }
    }
}
