using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4;
    Vector2 mousePosition;
    bool isMoving = false;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MoveToPosition();
        }
        if (Input.GetMouseButtonDown(0))
        {
            SetPlayerPosition();
        }
    }

    void SetPlayerPosition()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        isMoving = true;
    }

    void MoveToPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
    }
}
