using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Generators
{
	public static float SignedPerlinNoise(float x, float y) => (Mathf.PerlinNoise(x, y) - 0.5f) * 2;

    public static float RandomSign() => Random.Range(0, 2) == 0 ? -1 : 1;
}