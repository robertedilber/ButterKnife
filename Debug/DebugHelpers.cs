using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugHelpers {

    const float LEFT_OFFSET = 20, VERTICAL_OFFSET = 20, WIDTH = 500, HEIGHT = 20;
    ///Helper for quickly setuping custom debugs : just pass a ref int to
    public static void IncrementalLabel(ref int index, string text)
    {
        index++;
        GUI.Label(new Rect(LEFT_OFFSET, index * VERTICAL_OFFSET, WIDTH, HEIGHT), text);
    }
}
