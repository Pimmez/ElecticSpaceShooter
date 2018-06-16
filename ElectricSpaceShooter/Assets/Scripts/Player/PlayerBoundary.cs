using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{

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

	public float XMin { get { return xMin; } }
	public float XMax { get { return xMax; } }
	public float ZMin { get { return zMin; } }
	public float ZMax { get { return zMax; } }

	[SerializeField] private float xMin, xMax, zMin, zMax;

	public void BoundaryBox(Rigidbody rigid)
	{
		rigid.position = new Vector3(Mathf.Clamp(rigid.position.x, xMin, xMax), 0f, Mathf.Clamp(rigid.position.z, zMin, zMax));
	}
}