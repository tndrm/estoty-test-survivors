using UnityEngine;

public class RangedWeapon : MonoBehaviour, IWeapon, IReloadable, IAimWeapon
{
	[SerializeField] private Transform firePoint;

	private float shootingInterval;
	private GameObject bulletPrefab;
	private float nextFireTime = 0;
	private int currentAmmo;
	private int maxAmmo;
	private bool isReloaded = true;
	public void Initialize(WeaponConfig config)
	{
		currentAmmo = config.maxAmmo;
		maxAmmo = config.maxAmmo;
		shootingInterval = config.attackInterval;
		bulletPrefab = config.bulletPrefab;

	}

	public void Attack()
	{

		if (Time.time >= nextFireTime)
		{
			if (currentAmmo > 0)
			{
				Shoot();
				currentAmmo--;
				nextFireTime = Time.time + shootingInterval;
			}
			else
			{
				ShowAmmoMessage(false);
			}
		}
	}

	private void Shoot()
	{
		Instantiate(bulletPrefab, firePoint.position, transform.rotation, transform);
	}

	public bool Reload(int amount)
	{
		bool isReloadble = maxAmmo - currentAmmo > 0;
		currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
		currentAmmo += amount;
		ShowAmmoMessage(true);
		return isReloadble;
	}

	public void AimAndAttack(Transform target)
	{
		if (target != null)
		{
			Vector3 direction = (target.position - transform.position).normalized;

			if (direction.x < 0)
			{
				transform.localRotation = Quaternion.Euler(0, 180, 0) * Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, -direction.x) * Mathf.Rad2Deg);
			}
			else
			{
				transform.localRotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
			}

			Attack();
		}
	}

	private void ShowAmmoMessage(bool reloaded)
	{
		if (reloaded) Debug.Log("Ammo reloaded");
		if(isReloaded != reloaded && !reloaded)	Debug.Log("Out of ammo!");
		isReloaded = reloaded;

	}
}
