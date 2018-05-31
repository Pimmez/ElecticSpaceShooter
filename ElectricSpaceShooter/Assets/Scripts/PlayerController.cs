using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

	private const string HORIZONTAL = "Horizontal";
	private const string VERTICAL = "Vertical";

	[SerializeField] private float moveSpeed = 250f;
	[SerializeField] private float tilt;

	private Rigidbody rigid;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody>();
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
}