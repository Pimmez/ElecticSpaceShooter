using UnityEngine;

public class WeaponController : MonoBehaviour
{ 
	[SerializeField] private GameObject shot;
	[SerializeField] private Transform shotSpawn;
	[SerializeField] private float fireRate;
	[SerializeField] private float delay;

	[SerializeField] private float EnemyBulletLifeTime;
	[SerializeField] private float speed = 10f;
	private GameObject enemyBulletClone;

	void Start()
	{
		InvokeRepeating("Fire", delay, fireRate);
	}

	void Fire()
	{
		enemyBulletClone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		enemyBulletClone.GetComponent<Rigidbody>().velocity -= shot.transform.forward * speed;
		DeleteBullet(EnemyBulletLifeTime);


	}

	private void DeleteBullet(float _bulletLifeTime)
	{
		if (shot != null)
		{
			Destroy(enemyBulletClone, _bulletLifeTime);
		}
	}

}