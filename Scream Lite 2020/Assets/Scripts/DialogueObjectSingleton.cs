using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObjectSingleton : MonoBehaviour
{
    public List<GameObject> dialogueboxes = new List<GameObject>();
    public static DialogueObjectSingleton instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            foreach(GameObject can in dialogueboxes)
            {
                Destroy(can);
            }
            Destroy(this.gameObject);

        }
        else
        {
            foreach (GameObject can in dialogueboxes)
            {
                DontDestroyOnLoad(can);
            }
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

}
