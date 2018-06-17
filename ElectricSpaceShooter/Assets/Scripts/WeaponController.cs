using UnityEngine;

public class WeaponController : MonoBehaviour
{ 
	[SerializeField] private GameObject enemyBullet;
	[SerializeField] private Transform muzzle;
	[SerializeField] private float fireRate;
	[SerializeField] private float delay;
	[SerializeField] private float EnemyBulletLifeTime;
	[SerializeField] private float speed = 10f;

	private GameObject enemyBulletClone;

	private void Start()
	{
		InvokeRepeating("Fire", delay, fireRate);
	}

	private void Fire()
	{
		enemyBulletClone = Instantiate(enemyBullet, muzzle.position, muzzle.rotation);
		enemyBulletClone.GetComponent<Rigidbody>().velocity -= enemyBullet.transform.forward * speed;
		DeleteBullet(EnemyBulletLifeTime);
		AudioManager.Instance.PlayAudio(1);
	}

	private void DeleteBullet(float _bulletLifeTime)
	{
		if (enemyBullet != null)
		{
			Destroy(enemyBulletClone, _bulletLifeTime);
		}
	}
}