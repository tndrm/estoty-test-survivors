using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
	[SerializeField] private WeaponConfig leftWeaponConfig;
	[SerializeField] private WeaponConfig rightWeaponConfig;

	[SerializeField] private Transform leftHandPosition;
	[SerializeField] private Transform rightHandPosition;

	private EnemyFinder enemyFinder;

	private IWeapon leftWeapon;
	private IWeapon rightWeapon;
	private IReloadable leftReloadable;
	private IReloadable rightReloadable;
	private IAimWeapon leftAutoTargetWeapon;
	private IAimWeapon rightAutoTargetWeapon;

	private void Start()
	{
		ServiceLocator<object> serviceLocator = GameplayEntryPoint.ServiceLocator;


		enemyFinder = serviceLocator.Get<EnemyFinder>();
		SetLeftWeapon();
		SetRightWeapon();
	}

	private void SetLeftWeapon()
	{
		GameObject leftWeaponObject = Instantiate(leftWeaponConfig.weaponPrefab, leftHandPosition.position, Quaternion.identity, transform);
		leftWeapon = leftWeaponObject.GetComponent<IWeapon>();
		leftWeapon.Initialize(leftWeaponConfig);
		leftReloadable = leftWeaponObject.GetComponent<IReloadable>();
		leftAutoTargetWeapon = leftWeaponObject.GetComponent<IAimWeapon>();
	}
	private void SetRightWeapon()
	{
		GameObject rightWeaponObject = Instantiate(rightWeaponConfig.weaponPrefab, rightHandPosition.position, Quaternion.identity, transform);
		rightWeapon = rightWeaponObject.GetComponent<IWeapon>();
		rightWeapon.Initialize(rightWeaponConfig);
		rightReloadable = rightWeaponObject.GetComponent<IReloadable>();
		rightAutoTargetWeapon = rightWeaponObject.GetComponent<IAimWeapon>();
	}

	private void Update()
	{
		Transform target = enemyFinder.FindClosestEnemy();
		leftAutoTargetWeapon?.AimAndAttack(target);
		rightAutoTargetWeapon?.AimAndAttack(target);
	}

	public void Reload(int amount)
	{
		bool? isReloaded = leftReloadable?.Reload(amount);
		if (isReloaded == true) rightReloadable?.Reload(amount);
	}
}
