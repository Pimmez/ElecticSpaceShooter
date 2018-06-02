using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {

	[SerializeField] private List<GameObject> asteroids = new List<GameObject>();
	private Rigidbody rigid;
	[SerializeField] private float rotateAmount;

	void Start ()
	{
		for (int i = 0; i < asteroids.Count; i++)
		{
			Instantiate(asteroids[i].gameObject, asteroids[i].transform.position, Quaternion.identity);
			asteroids[i].transform.position = new Vector3(0, 0, 5);
		}
	}
}