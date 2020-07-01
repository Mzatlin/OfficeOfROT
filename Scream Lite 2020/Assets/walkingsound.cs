using Boo.Lang.Environments;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class walkingsound : MonoBehaviour
{

    
   
    public Rigidbody2D rb;
    private ClickToMove clickToMove;


    // Start is called before the first frame update
    void Start()
    {
        transform.hasChanged = false;
       
    }

    // Update is called once per frame
    void Update()
    {
       

        if (transform.hasChanged)
        {
            transform.hasChanged = false;
        }
        else
        {
            clickToMove.MyEvent.Stop(gameObject); 
                
            
        }
    }


    
}
