using UnityEngine;

public static class QuaternionHelpers
{
	public static Quaternion GetDelta(this Quaternion quat, Quaternion target)
		=> target * Quaternion.Inverse(quat);

	public static Quaternion ApplyDelta(this Quaternion quat, Quaternion delta)
		=> quat * delta;
}