using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerOnClick : GameObjectPathingBase, IMove
{
    public GameObject walkLocation;
    public float moveSpeed = 4;
    public LayerMask floorMask;
    ICameraRaycast raycast;
    Vector2 mousePosition;
    bool isMoving = false;
    Camera cam;
    Animator animate;

    public AK.Wwise.Event MyEvent = null;

    bool IMove.isMoving { get => isMoving; set => isMoving = value; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        cam = Camera.main;
        animate = GetComponentInChildren<Animator>();
        raycast = cam.GetComponent<ICameraRaycast>();
        walkLocation.SetActive(false);
    }

    void OnDestroy()
    {
        MyEvent.Stop(gameObject);
        isMoving = false;
    }


    // Update is called once per frame
    void Update()
    {
        ReadInput();
        if (isMoving && path != null)
        {
            animate.SetFloat("MoveX",Mathf.Abs(rb.velocity.x));
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
        if(Input.GetMouseButtonDown(0) && raycast.CanCast && raycast.RayHit)
        {
            if ((1 << raycast.RayHit.collider.gameObject.layer & floorMask) != 0)
            {
                PlaySound();
                mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
                UpdatePath();
                isMoving = true;
                walkLocation.transform.position = mousePosition;
                walkLocation.SetActive(true);
            }
        }
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
        if (Vector3.Distance(transform.position, mousePosition) <= 2.5f)
        {
            isMoving = false;
            animate.SetFloat("MoveX", 0f);
        }
    }
}
