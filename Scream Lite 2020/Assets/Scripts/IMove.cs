using Pathfinding;

internal interface IMove
{
    bool IsMoving { get; set; }
    Path MovePath { get;  }
}