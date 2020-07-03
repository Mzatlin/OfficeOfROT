using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
public class GameObjectPathingBase : MonoBehaviour
{
    [SerializeField]
    protected Transform target;
    [SerializeField]
    protected float objectSpeed = 200f;
    [SerializeField]
    protected float distanceToNextWayPoint = 3f;

    protected Path path;
    protected Seeker seeker;
    protected Rigidbody2D rb;
    protected Vector2 direction;

    protected int currentWayPoint = 0;
    protected bool reachedEndOfPath = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    protected void OnPathComplete(Path _path)
    {
        if (!_path.error)
        {
            path = _path;
            currentWayPoint = 0;
        }
    }

    protected void MoveSeeker()
    {
            direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized; //Displacement Vector or length 1 
            Vector2 force = objectSpeed * direction * Time.deltaTime;
            rb.AddForce(force);
    }

    protected void CheckPathing()
    {
        if (path == null)
            return;

        if (currentWayPoint >= path.vectorPath.Count-1)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
    }

    protected void UpdateWayPoint()
    {
        if (Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]) < distanceToNextWayPoint)
        {
            if(currentWayPoint < path.vectorPath.Count-1)
            {
                currentWayPoint++;
            }

        }
    }


}
