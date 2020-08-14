using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTarget : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float moveSpeed = 3;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
