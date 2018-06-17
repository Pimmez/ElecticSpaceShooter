using UnityEngine;
using System;

public class Asteroid : MonoBehaviour
{
	public static Action<int> scoreIncreaseEvent;

	[SerializeField] private float rotateAmount;
	[SerializeField] private float moveSpeed;
	[SerializeField] private int score;

	private Rigidbody rigid;

	void Start()
	{
		rigid = GetComponent<Rigidbody>();
		rigid.angularVelocity = UnityEngine.Random.insideUnitSphere * rotateAmount;
		rigid.velocity = -transform.forward * moveSpeed;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == Tags.DEADTRIGGER)
		{
			Destroy(gameObject);
		}
		if(other.gameObject.tag == Tags.BULLET)
		{
			Destroy(gameObject);
			ParticleLibrary.Instance.SpawnParticle(transform.position, 0);
			Destroy(other.gameObject);

			AudioManager.Instance.PlayAudio(4);

			if (scoreIncreaseEvent != null)
			{
				scoreIncreaseEvent(score);
			}
		}
	}
}