using UnityEngine;
using System;

public class EnemyMover : MonoBehaviour
{
	public static Action<int> enemyDiedEvent;

	[SerializeField] private int score;
	[SerializeField] private float speed;

	private void Update()
	{
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == Tags.DEADTRIGGER)
		{
			Destroy(gameObject);
		}
		if (other.gameObject.tag == Tags.BULLET)
		{
			Destroy(gameObject);
			ParticleLibrary.Instance.SpawnParticle(transform.position, 0);
			Destroy(other.gameObject);
			if (enemyDiedEvent != null)
			{
				enemyDiedEvent(score);
			}
		}
	}
}