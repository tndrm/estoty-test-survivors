using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Gameplay/Weapon Config", order = 1)]
public class WeaponConfig : ScriptableObject
{
	public string weaponName;
	public float damage;
	public int maxAmmo;
	public GameObject weaponPrefab;
	public GameObject bulletPrefab;
	public float attackRange;
	public float attackInterval;
}
