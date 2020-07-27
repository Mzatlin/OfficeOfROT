using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDeath : MonoBehaviour, IHealth
{
   public event Action OnDie;
    bool isDead = false;
    public bool IsDead { get => isDead; set => isDead = value; }
    ILoadScene scene;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        scene = GetComponent<ILoadScene>();
    }

    public void ProcessDamage()
    {
        isDead = true;
        scene.LoadScene();
        OnDie?.Invoke();
    }




}
