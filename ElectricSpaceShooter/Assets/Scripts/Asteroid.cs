using UnityEngine;

public class Asteroid : MonoBehaviour {

	private Rigidbody rigid;
	[SerializeField] private float rotateAmount;

	void Start()
	{
		rigid = GetComponent<Rigidbody>();
		rigid.angularVelocity = Random.insideUnitSphere * rotateAmount;
	}

	private void OnTriggerEnter(Collider other)
	{
		ParticleLibrary.Instance.SpawnParticle(transform.position);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
