using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerOnDeath : MonoBehaviour
{
    IMove move;
    IHealth health;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<IMove>();
        health = GetComponent<IHealth>();
        if(health != null)
        {
            health.OnDie += HandleDeath;
        }
    }

    void OnDestroy()
    {
        health.OnDie -= HandleDeath;
    }

    private void HandleDeath()
    {
        move.IsMoving = false;
    }


}
