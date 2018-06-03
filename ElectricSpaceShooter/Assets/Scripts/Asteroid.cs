using UnityEngine;

public class Asteroid : MonoBehaviour {

	[SerializeField] private float rotateAmount;
	[SerializeField] private float moveSpeed;

	

	private Rigidbody rigid;

	void Start()
	{
		rigid = GetComponent<Rigidbody>();
		rigid.angularVelocity = Random.insideUnitSphere * rotateAmount;
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
		}
		if (other.gameObject.tag == Tags.PLAYER)
		{
			Destroy(gameObject);
			ParticleLibrary.Instance.SpawnParticle(transform.position, 1);
			Destroy(other.gameObject);
		}
	}
}
