using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
public class PathToTarget : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float enemySpeed = 200f;
    [SerializeField]
    float distanceToNextWayPoint = 3f;

    Path path;
    Seeker seeker;
    Rigidbody2D rb;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
      
    }

    void OnPathComplete(Path _path)
    {
        if (!_path.error)
        {
            path = _path;
            currentWayPoint = 0;
        }
    }

    void MoveSeeker()
    {

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized; //Displacement Vector or length 1 
        Vector2 force = enemySpeed * direction * Time.deltaTime;
        rb.AddForce(force);
    }

    void CheckPathing()
    {
        if (path == null)
            return;

        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
    }

    void UpdateWayPoint()
    {
        if (Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]) < distanceToNextWayPoint)
        {
            currentWayPoint++;
        }
    }

    void FixedUpdate()
    {

        CheckPathing();
        MoveSeeker();
        UpdateWayPoint();

    }




}
