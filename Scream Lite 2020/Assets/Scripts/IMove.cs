using Pathfinding;
using UnityEngine;

internal interface IMove
{
    bool IsMoving { get; set; }
    Path MovePath { get;  }
    void MovePlayer(Vector2 position);
}