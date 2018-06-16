using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class AsteroidSpawn : MonoBehaviour
{
	[SerializeField] private List<GameObject> asteroids = new List<GameObject>();
	[SerializeField] private float rotateAmount;
	[SerializeField] private Vector3 spawnValues;
	[SerializeField] private float spawnWait;
	[SerializeField] private float startWait;
	[SerializeField] private float waveWait;

	private Coroutine spawnWave;

	void Start ()
	{
		spawnWave = StartCoroutine(SpawnWaves());
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < asteroids.Count; i++)
			{
				Vector3 _spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion _spawnRotation = new Quaternion();
				Instantiate(asteroids[i].gameObject, _spawnPosition, _spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if(GameOverUI.Instance.IsGameOver == true)
			{
				break;
			}
		}
	}
}