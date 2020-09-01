using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class MovePlayerOnClick : GameObjectPathingBase, IMove
{
    public GameObject walkLocation;
    public float moveSpeed = 4;
    float stopDistance = 2.65f;
    public LayerMask floorMask;
    ICameraRaycast raycast;
    Vector2 mousePosition;
    [SerializeField]
    bool isMoving = false;
    Camera cam;

    public AK.Wwise.Event MyEvent = null;

    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public Path MovePath => path;

   
    protected override void Start()
    {
        base.Start();
        cam = Camera.main;
        raycast = cam.GetComponent<ICameraRaycast>();
        walkLocation.SetActive(false);
    }

    void OnDestroy()
    {
        MyEvent.Stop(gameObject);
        isMoving = false;
    }


    
    void Update()
    {
        if (raycast.CanCast)
        {
            ReadInput();
        }
        if (isMoving && path != null)
        {
            CheckPathing();
            MoveSeeker();
            UpdateWayPoint();
            CheckPosition();
        }
        else
        {
            MyEvent.Stop(gameObject);
            walkLocation.SetActive(false);
        }

    }

    void ReadInput()
    {
        //Only when a click is registered and the raycast is able to process the floor layer can the player move to position 
        if (Input.GetMouseButtonDown(0) && raycast.RayHit)
        {
            if ((1 << raycast.RayHit.collider.gameObject.layer & floorMask) != 0)
            {
                mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
                MovePlayer(mousePosition);
            }
        }
    }

    public void MovePlayer(Vector2 position)
    {
        PlaySound();
        UpdatePath();
        isMoving = true;
        walkLocation.transform.position = position;
        walkLocation.SetActive(true);
    }

    void PlaySound()
    {
        if (!isMoving)
        {
            MyEvent.Post(gameObject);
        }
    }

    protected override void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, mousePosition, OnPathComplete);
        }
    }


    void CheckPosition()
    {
        //The only thing that stops the player is a distance check between the player's position and the position of the mouse click 
        if (Vector3.Distance(transform.position, mousePosition) <= stopDistance)
        {
            isMoving = false;
        }
    }
}
