using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObjectToPosition : MonoBehaviour
{
    [SerializeField]
    LayerMask targetMask;
    [SerializeField]
    GameObject location;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & targetMask) != 0)
        {
            var move = collision.GetComponent<IMove>();
            if(move != null)
            {
                move.isMoving = false;
                collision.transform.position = location.transform.position;
            }

        }
    }
}
