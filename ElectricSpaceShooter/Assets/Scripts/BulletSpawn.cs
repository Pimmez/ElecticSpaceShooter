using UnityEngine;

public class BulletSpawn : MonoBehaviour {

	public static BulletSpawn Instance { get { return GetInstance(); } }

	#region Singleton
	private static BulletSpawn instance;

	private static BulletSpawn GetInstance()
	{
		if (instance == null)
		{
			instance = FindObjectOfType<BulletSpawn>();
		}
		return instance;
	}
	#endregion

	[SerializeField] private float bulletLifeTime;
	[SerializeField] private GameObject bullet;
	[SerializeField] private float speed = 10f;
	private GameObject bulletClone;

	public void InstantiateBullet(Vector3 _playerBlaster)
	{
		bulletClone = Instantiate(bullet, _playerBlaster, bullet.transform.rotation) as GameObject;
		bulletClone.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;
		DeleteBullet(bulletLifeTime);
	}

	private void DeleteBullet(float _bulletLifeTime)
	{
		if (bullet != null)
		{
			Destroy(bulletClone, _bulletLifeTime);
		}
	}
}