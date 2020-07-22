using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorOnStart : MonoBehaviour
{
    public CursorMode cursorMode = CursorMode.Auto;
    Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

}
