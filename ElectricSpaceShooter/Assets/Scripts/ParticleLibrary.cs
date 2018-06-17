using System.Collections.Generic;
using UnityEngine;

public class ParticleLibrary : MonoBehaviour
{
	public static ParticleLibrary Instance { get { return GetInstance(); } }

	#region Singleton
	private static ParticleLibrary instance;

	private static ParticleLibrary GetInstance()
	{
		if (instance == null)
		{
			instance = FindObjectOfType<ParticleLibrary>();
		}

		return instance;
	}
	#endregion

	[SerializeField] private List<GameObject> particles = new List<GameObject>();

	public void SpawnParticle(Vector3 _position, int _particleCounter)
	{
		for (int i = 0; i < particles.Count; i++)
		{
			GameObject _particleClone = Instantiate(particles[_particleCounter], _position, particles[i].transform.rotation);
			Destroy(_particleClone, 1f);
		}
	}
}