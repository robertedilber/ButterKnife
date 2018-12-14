using UnityEngine;

public static class VectorHelpers
{
    #region Helpers

    public static Vector3 ProjectOnPlane(Vector3 vectorToProject, Vector3 normal)
        => vectorToProject - Dot(normal, vectorToProject) * normal;

    public static Vector3 ProjectOnPlane(Vector3 vectorToProject, Vector3 normal, Vector3 planeOrigin)
        => vectorToProject - Dot(normal, (vectorToProject - planeOrigin)) * normal;

    public static float Dot(Vector3 a, Vector3 b)
        => (a.x * b.x) + (a.y * b.y) + (a.z * b.z);

    public static Vector3 Cross(Vector3 a, Vector3 b)
        => new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);

    public static Vector3 GetCentroid(Vector3[] points)
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

    public static Vector3 GetMiddlePoint(Vector3 a, Vector3 b) => a + (b - a) / 2;

    public static float GetAngeInRadians(Vector3 a, Vector3 b)
    {
        a.Normalize();
        b.Normalize();
        float[] cross = new float[] { a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x };
        float[] normal = new float[] { Mathf.Abs(cross[0]), Mathf.Abs(cross[1]), Mathf.Abs(cross[2]) };
        float orientation = normal[0] * cross[0] + normal[1] * cross[1] + normal[2] * cross[2];
        float angle = Mathf.Acos(a.x * b.x + a.y * b.y + a.z * b.z) * Mathf.Sign(orientation);
        return angle + (angle < 0.0f ? 2 * Mathf.PI : 0);
    }

    #endregion

    #region Extensions Methods

    public static Vector3 Absolute(this Vector3 a) => new Vector3(Mathf.Abs(a.x), Mathf.Abs(a.y), Mathf.Abs(a.z));

    #endregion
}