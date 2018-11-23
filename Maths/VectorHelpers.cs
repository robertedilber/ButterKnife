using UnityEngine;

public static class VectorHelpers
{
	public static Vector3 ProjectOnPlane(Vector3 point, Vector3 normal)
		=> point - DotProduct(normal, point) * normal;

	public static Vector3 ProjectOnPlane(Vector3 point, Vector3 normal, Vector3 planeOrigin)
		=> point - DotProduct(normal, (point - planeOrigin)) * normal;

	public static float DotProduct(Vector3 v1, Vector3 v2)
		=> (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);

	public static Vector3 GetCentroid(Vector3[] points)
	{
		Vector3 avgPos = Vector3.zero;
		for (int i = 0; i < points.Length; i++)
			avgPos += points[i];
		avgPos /= points.Length;
		return avgPos;
	}

	public static Vector3 GetMiddlePoint(Vector3 a, Vector3 b) => a + (b - a) / 2;
}