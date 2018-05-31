using UnityEngine;

public class PlayerBoundary : MonoBehaviour {

	public static PlayerBoundary Instance { get { return GetInstance(); } }

	#region Singleton
	private static PlayerBoundary instance;

	private static PlayerBoundary GetInstance()
	{
		if (instance == null)
		{
			instance = FindObjectOfType<PlayerBoundary>();
		}
		return instance;
	}
	#endregion

	[SerializeField] private float xMin, xMax, zMin, zMax;

	public void BoundaryBox(Rigidbody rigid)
	{
		rigid.position = new Vector3(Mathf.Clamp(rigid.position.x, xMin, xMax), 0f, Mathf.Clamp(rigid.position.z, zMin, zMax));
	}
}