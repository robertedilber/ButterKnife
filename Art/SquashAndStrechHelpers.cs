using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArtHelpers
{

    public static void Squash(this Transform target, float offset)
    {
        float newYValue = 1 + (offset);
        float newXZValue = 1 - (offset / 2);
        target.localScale = new Vector3(newXZValue, newYValue, newXZValue);
    }

}
