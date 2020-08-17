using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapGameObjectsOnDialogueEnd : MonoBehaviour
{
  //  AnimationEvent animate;
    [SerializeField]
    List<GameObject> disappearObjects = new List<GameObject>();
    [SerializeField]
    List<GameObject> appearObjects = new List<GameObject>();
    bool swapper = false;
 
    // Start is called before the first frame update
    void Start()
    {
   //     animate = GetComponent<AnimationEvent>();
        Swap(appearObjects);
        Swap(disappearObjects);
    }

    public void HandleTipOverEvent()
    {
        HandleSpawn();
    }

    private void Swap(List<GameObject> gameObjects)
    {
        foreach(GameObject obj in gameObjects)
        {
            obj.SetActive(swapper);
        }
        swapper = !swapper;
    }

    private void HandleSpawn()
    {
        Swap(disappearObjects);
        Swap(appearObjects);
    }
}
