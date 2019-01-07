using System;
using UnityEngine;

public static class VectorHelpers
{
    #region Helpers

    public static Vector3 ProjectOnPlane(Vector3 vectorToProject, Vector3 normal)
        => vectorToProject - ((normal.x * vectorToProject.x) + (normal.y * vectorToProject.y) + (normal.z * vectorToProject.z)) * normal;

    public static Vector3 ProjectOnPlane(Vector3 vectorToProject, Vector3 normal, Vector3 planeOrigin)
    {
        Vector3 v = vectorToProject - planeOrigin;
        return vectorToProject - ((normal.x * v.x) + (normal.y * v.y) + (normal.z * v.z)) * normal;
    }

    public static float Dot(Vector3 a, Vector3 b) => (a.x * b.x) + (a.y * b.y) + (a.z * b.z);

    public static Vector3 Cross(Vector3 a, Vector3 b) => new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);

    public static Vector3 Centroid(Vector3[] points)
    {
        float[] centroid = new float[] { 0.0f, 0.0f, 0.0f };
        int numberOfPoints = points.Length;
        for (int i = 0; i < numberOfPoints; i++)
        {
            centroid[0] += points[i].x;
            centroid[1] += points[i].y;
            centroid[2] += points[i].z;
        }

        for (int i = 0; i < 3; i++)
            centroid[i] /= numberOfPoints;

        return new Vector3(centroid[0], centroid[1], centroid[2]);
    }

    public static Vector3 Centroid(Vector3 a, Vector3 b) => a + (b - a) / 2;

    public static float AngleInRadians(Vector3 a, Vector3 b, Vector3 normal)
    {
        a.Normalize();
        b.Normalize();
        float[] cross = new float[] { a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x };
        float orientation = normal.x * cross[0] + normal.y * cross[1] + normal.z * cross[2];
        orientation = orientation < 0.0f ? -1 : 1;
        float angle = Mathf.Acos(Mathf.Clamp(a.x * b.x + a.y * b.y + a.z * b.z, -1, 1)) * Mathf.Sign(orientation);
        return angle + (angle < 0.0f ? 2 * Mathf.PI : 0);
    }

    #endregion

    #region Extensions Methods

    public static Vector3 Absolute(this Vector3 a) => new Vector3(Mathf.Abs(a.x), Mathf.Abs(a.y), Mathf.Abs(a.z));
    public static void Absolute(ref this Vector3 a)
    {
        a.x = Mathf.Abs(a.x);
        a.y = Mathf.Abs(a.y);
        a.z = Mathf.Abs(a.z);
    }

    #endregion
}