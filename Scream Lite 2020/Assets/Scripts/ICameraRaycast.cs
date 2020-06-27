using UnityEngine;
public interface ICameraRaycast
{
    LayerMask ObjectLayer { get; }
    RaycastHit2D RayHit { get; }
}