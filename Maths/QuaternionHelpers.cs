using UnityEngine;

public static class QuaternionHelpers
{
	public static Quaternion GetDelta(this Quaternion quat, Quaternion target)
		=> target * Quaternion.Inverse(quat);

	public static Quaternion ApplyDelta(this Quaternion quat, Quaternion delta)
		=> quat * delta;

	/// <summary>
	/// Transforms a rotation from local space to world space
	/// </summary>
	public static Quaternion LocalToWorldQuaternion(this Transform t, Quaternion rotation)
		=> t.rotation * rotation;

	/// <summary>
	/// Transforms a rotation from world space to local space
	/// </summary>
	public static Quaternion WorldToLocalQuaternion(this Transform t, Quaternion rotation)
		=> Quaternion.Inverse(t.rotation) * rotation;
}