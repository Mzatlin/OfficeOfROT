using UnityEngine;
using Pathfinding;


public class PathToTarget : GameObjectPathingBase
{
    SpriteRenderer renderer;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        InvokeRepeating("UpdatePath", 0f, .5f);
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(path != null)
        {
            CheckPathing();
            MoveSeeker();
            UpdateWayPoint();
        }

    }






}
