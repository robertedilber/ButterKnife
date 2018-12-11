using UnityEngine;

public static class QuaternionHelpers
{
    public static Quaternion GetDelta(this Quaternion quat, Quaternion target)
        => target * Quaternion.Inverse(quat);

    public static Quaternion ApplyDelta(this Quaternion quat, Quaternion delta)
        => quat * delta;

    public static Quaternion Define(Vector3 axis, float theta)
    {
        Vector3 ijk = Mathf.Sin(theta / 2) * axis;
        return new Quaternion(ijk.x, ijk.y, ijk.z, Mathf.Cos(theta / 2));
    }
}