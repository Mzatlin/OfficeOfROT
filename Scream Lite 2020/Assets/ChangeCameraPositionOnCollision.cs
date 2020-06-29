using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPositionOnCollision : MonoBehaviour
{
    Camera cam;
    [SerializeField]
    LayerMask targetMask;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & targetMask) != 0)
        {
            cam.transform.position = transform.position;
        }
    }
}
