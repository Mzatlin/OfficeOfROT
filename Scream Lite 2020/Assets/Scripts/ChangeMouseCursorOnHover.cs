using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMouseCursorOnHover : MonoBehaviour
{
    ICameraRaycast raycast;
    public List<Texture2D> textures;
    public List<string> layermasks;

    public Dictionary<string, Texture2D> cursors = new Dictionary<string, Texture2D>();
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        raycast = GetComponent<ICameraRaycast>();
        CreateDictionary();
    }

    void CreateDictionary()
    {
        int index = 0;
        foreach(string layer in layermasks)
        {

            if (!cursors.ContainsKey(layer))
            {
                cursors.Add(layer, textures[index]);
                index++;
            }
        }


    }

    void Update()
    {
        if(raycast != null && raycast.RayHit)
        {
            var layer = LayerMask.LayerToName(raycast.RayHit.collider.gameObject.layer);
            if (cursors.ContainsKey(layer))
            {
                Debug.Log("found");
                Cursor.SetCursor(cursors[layer], hotSpot, cursorMode);
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, cursorMode);
            }
               
        }    
    }
}
