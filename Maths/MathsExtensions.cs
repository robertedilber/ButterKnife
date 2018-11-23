using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MathsExtensions
{
	#region Vector3

	public static Vector3 Min(this Vector3 vector, float min)
	{
		float x = Mathf.Min(vector.x, min);
		float y = Mathf.Min(vector.y, min);
		float z = Mathf.Min(vector.z, min);
		return new Vector3(x, y, z);
	}

	public static Vector3 Max(this Vector3 vector, float max)
	{
		float x = Mathf.Max(vector.x, max);
		float y = Mathf.Max(vector.y, max);
		float z = Mathf.Max(vector.z, max);
		return new Vector3(x, y, z);
	}

	public static Vector3 Clamp(this Vector3 vector, float min, float max)
	{
		float x = Mathf.Clamp(vector.x, min, max);
		float y = Mathf.Clamp(vector.y, min, max);
		float z = Mathf.Clamp(vector.z, min, max);
		return new Vector3(x, y, z);
	}

	public static Vector3 OverrideAll(this Vector3 vector, float? x, float? y, float? z)
		=> new Vector3(x != null ? x.Value : vector.x, y != null ? y.Value : vector.y, z != null ? z.Value : vector.z);

	public static Vector3 OverrideX(this Vector3 vector, float x)
		=> new Vector3(x, vector.y, vector.z);

	public static Vector3 OverrideY(this Vector3 vector, float y)
		=> new Vector3(vector.x, y, vector.z);

	public static Vector3 OverrideZ(this Vector3 vector, float z)
		=> new Vector3(vector.x, vector.y, z);

	#endregion

	#region Vector2

	public static Vector2 OverrideAll(this Vector2 vector, float? x, float? y)
		=> new Vector2(x != null ? x.Value : vector.x, y != null ? y.Value : vector.y);

	public static Vector2 OverrideX(this Vector2 vector, float x)
		=> new Vector2(x, vector.y);

	public static Vector2 OverrideY(this Vector2 vector, float y)
		=> new Vector2(vector.x, y);

	#endregion

	#region Color

	public static Color OverrideAlpha(this Color color, float a)
		=> new Color(color.r, color.g, color.b, a);

	public static Color OverrideR(this Color color, float r)
		=> new Color(r, color.b, color.b, color.a);

	public static Color OverrideG(this Color color, float g)
		=> new Color(color.r, g, color.b, color.a);

	public static Color OverrideB(this Color color, float b)
		=> new Color(color.r, color.g, b, color.a);

	#endregion
}