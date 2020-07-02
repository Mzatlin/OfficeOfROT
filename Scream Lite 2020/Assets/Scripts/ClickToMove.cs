using Boo.Lang.Environments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour, IMove
{
    [SerializeField]
    float moveSpeed = 4;
    [SerializeField]
    LayerMask floorMask;
    ICameraRaycast raycast;
    Vector2 mousePosition;
    bool isMoving = false;
    Camera cam;

    public AK.Wwise.Event MyEvent = null;

    bool IMove.isMoving { get => isMoving; set => isMoving = value; }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        raycast = cam.GetComponent<ICameraRaycast>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MoveToPosition();
            
        }
        else
        {
            MyEvent.Stop(gameObject);
        }
        if (Input.GetMouseButtonDown(0) && raycast.RayHit && (1 << raycast.RayHit.collider.gameObject.layer & floorMask) != 0)
        {
            SetPlayerPosition();
            
        }
   
    }

    void SetPlayerPosition()
    {
        MyEvent.Post(gameObject);
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        isMoving = true;
    }

    void MoveToPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, mousePosition) < 0.01)
        {
            isMoving = false;
        }
    }
}
