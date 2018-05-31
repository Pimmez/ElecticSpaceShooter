using UnityEngine;

public class BulletMover : MonoBehaviour {

	[SerializeField] private float bulletSpeed = 20f;
	private Rigidbody rigid;

	void Start () {
		rigid = GetComponent<Rigidbody>();
		rigid.velocity = transform.forward * bulletSpeed;
	}
}
