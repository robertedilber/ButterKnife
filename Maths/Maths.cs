using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Generators
{
	public static float SignedPerlinNoise(float x, float y) => (Mathf.PerlinNoise(x, y) - 0.5f) * 2;
}