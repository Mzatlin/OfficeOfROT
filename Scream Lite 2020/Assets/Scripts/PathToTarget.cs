using UnityEngine;
using Pathfinding;


public class PathToTarget : GameObjectPathingBase
{
   
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void FixedUpdate()
    {
            CheckPathing();
            MoveSeeker();
            UpdateWayPoint();
    }




}
