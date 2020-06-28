using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTargetOnCollision : MonoBehaviour
{
    [SerializeField]
    LayerMask targetMask;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((1 << collision.gameObject.layer & targetMask) != 0)
        {
            var player = collision.GetComponent<IHealth>();
            if(player != null)
            {
                player.ProcessDamage();
            }
        }
    }
}
