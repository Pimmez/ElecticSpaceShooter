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
	private GameObject bulletClone;

	public void InstantiateBullet(Vector3 _playerBlaster)
	{
		bulletClone = (GameObject)Instantiate(bullet, _playerBlaster, transform.rotation);
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