using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUIOnDeath : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    IHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<IHealth>();
        health.OnDie += HandleDie;
        canvas.enabled = false;
    }

    private void HandleDie()
    {
        canvas.enabled = true;
    }
}
