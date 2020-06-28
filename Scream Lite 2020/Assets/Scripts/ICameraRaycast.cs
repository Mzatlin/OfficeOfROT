using UnityEngine;
public interface ICameraRaycast
{
    bool CanCast { get; set; }
    LayerMask ObjectLayer { get; }
    RaycastHit2D RayHit { get; }
}