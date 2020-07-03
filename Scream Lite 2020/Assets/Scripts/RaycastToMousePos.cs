using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastToMousePos : MonoBehaviour, ICameraRaycast
{
    [SerializeField]
    LayerMask objectLayer;
    RaycastHit2D objectHit;
    bool canCast = true;
    Camera cam;


    public RaycastHit2D RayHit { get => objectHit; }
    public LayerMask ObjectLayer { get => objectLayer; }
    public bool CanCast { get => canCast; set => canCast = value; }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame

    void Update()
    {
        if (canCast)
        {
            DrawRaycast();
           
        }
   
    }

    void DrawRaycast()
    {
        objectHit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 10f, objectLayer);
        if (objectHit)
        {
            CheckForInteraction();
        }
    }

    void CheckForInteraction()
    {
        var interact = objectHit.transform.GetComponent<IInteract>();
        if (interact != null && Input.GetMouseButtonDown(0))
        {
            interact.ProcessInteraction();
        }
    }
}
