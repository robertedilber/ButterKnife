using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	// Instanciated version of this MonoBehaviour
	public static T s_Instance { get; set; }

	protected virtual void Awake()
	{
		// If the Instance is already set, destroy this instance
		if (s_Instance != null)
			Destroy(this);
		else
			s_Instance = this as T;
	}

	protected virtual void OnDestroy()
	{
		// Set the instance to null when this instance is destroyed
		s_Instance = null;
	}
}
