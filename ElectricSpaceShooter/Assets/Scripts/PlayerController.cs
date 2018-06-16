using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
	public static Action playerDiedEvent;

	private const string HORIZONTAL = "Horizontal";
	private const string VERTICAL = "Vertical";

	[SerializeField] private float moveSpeed = 250f;
	[SerializeField] private float tilt;
	[SerializeField] private GameObject blasterNose;
	[SerializeField] private float fireRate;

	private Vector3 playerStartPosition = new Vector3(0, 0, -5);
	private Rigidbody rigid;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;

	private float nextFire;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody>();
		gameObject.transform.position = playerStartPosition;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			BulletSpawn.Instance.InstantiateBullet(blasterNose.transform.position);
		}
	}

	private void FixedUpdate()
	{
		MoveAround();
		PlayerBoundary.Instance.BoundaryBox(rigid);
	}

	private void MoveAround()
	{
		moveHorizontal = Input.GetAxis(HORIZONTAL);
		moveVertical = Input.GetAxis(VERTICAL);
		movement = new Vector3(moveHorizontal, 0, moveVertical);
		rigid.velocity = movement * (moveSpeed * Time.deltaTime);
		rigid.rotation = Quaternion.Euler(0, 0, rigid.velocity.x * -tilt);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == Tags.ASTEROID)
		{
			Destroy(gameObject);
			ParticleLibrary.Instance.SpawnParticle(transform.position, 1);
			Destroy(other.gameObject);

			if (playerDiedEvent != null)
			{
				playerDiedEvent();
			}
		}
	}
}