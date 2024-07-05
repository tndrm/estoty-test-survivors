using UnityEngine;

public class MeleeWeapon : MonoBehaviour, IWeapon
{
	private float attackInterval;


	public void Initialize(WeaponConfig config)
	{
		attackInterval = config.attackInterval;

	}
	public void Attack()
	{
		throw new System.NotImplementedException();
	}
}
