using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AnimatePlayerMovement : MonoBehaviour
{
    Animator animate;
    IMove move;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponentInChildren<Animator>();
        move = GetComponent<IMove>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
    }

    void CheckMovement()
    {
        if(move != null && move.IsMoving == true && move.MovePath != null)
        {
            animate.SetFloat("MoveX", Mathf.Abs(rb.velocity.x));
            animate.SetFloat("MoveY", rb.velocity.y); //might have to check if y is greater than 0.1 just in case the two animation direcitons fight.
        }
        else
        {
            animate.SetFloat("MoveX", 0f);
            animate.SetFloat("MoveY", 0f);
        }
    }
}
