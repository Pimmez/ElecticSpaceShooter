using System.Collections.Generic;
using UnityEngine;

public class ParticleLibrary : MonoBehaviour {

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

	[SerializeField] private List<ParticleSystem> particles = new List<ParticleSystem>();

	public void SpawnParticle(Vector3 _position)
	{
		for (int i = 0; i < particles.Count; i++)
		{
			Instantiate(particles[i], _position, particles[i].transform.rotation);
		}
	}
}