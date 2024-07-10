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

	private SpriteRenderer leftWeaponSpriteRenderer;
	private SpriteRenderer rightWeaponSpriteRenderer;

	private Vector3 previousPosition;
	private SpriteRenderer playerSpriteRenderer;


	private void Start()
	{
		ServiceLocator<object> serviceLocator = GameplayEntryPoint.ServiceLocator;


		enemyFinder = serviceLocator.Get<EnemyFinder>();
		SetLeftWeapon();
		SetRightWeapon();
		playerSpriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void SetLeftWeapon()
	{
		GameObject leftWeaponObject = Instantiate(leftWeaponConfig.weaponPrefab, leftHandPosition.position, Quaternion.identity, transform);
		leftWeapon = leftWeaponObject.GetComponent<IWeapon>();
		leftWeapon.Initialize(leftWeaponConfig);
		leftReloadable = leftWeaponObject.GetComponent<IReloadable>();
		leftAutoTargetWeapon = leftWeaponObject.GetComponent<IAimWeapon>();
		leftWeaponSpriteRenderer = leftWeaponObject.GetComponent<SpriteRenderer>();
	}
	private void SetRightWeapon()
	{
		GameObject rightWeaponObject = Instantiate(rightWeaponConfig.weaponPrefab, rightHandPosition.position, Quaternion.identity, transform);
		rightWeapon = rightWeaponObject.GetComponent<IWeapon>();
		rightWeapon.Initialize(rightWeaponConfig);
		rightReloadable = rightWeaponObject.GetComponent<IReloadable>();
		rightAutoTargetWeapon = rightWeaponObject.GetComponent<IAimWeapon>();
		rightWeaponSpriteRenderer = rightWeaponObject.GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		Transform target = enemyFinder.FindClosestEnemy();
		leftAutoTargetWeapon?.AimAndAttack(target);
		rightAutoTargetWeapon?.AimAndAttack(target);
	}

	private void LateUpdate()
	{
				ChangeWeaponSpriteOrder();
	}

	public void Reload(int amount)
	{
		bool? isReloaded = leftReloadable?.Reload(amount);
		if (isReloaded == true) rightReloadable?.Reload(amount);
	}

	private void ChangeWeaponSpriteOrder()
	{
		Vector3 currentPosition = transform.position;
		Vector3 direction = currentPosition - previousPosition;
		int playerSortOrder = playerSpriteRenderer.sortingOrder;
		if (direction.x > 0)
		{
			// Moving right
			leftWeaponSpriteRenderer.sortingOrder = playerSortOrder - 1;
			rightWeaponSpriteRenderer.sortingOrder = playerSortOrder + 1;
		}
		else if (direction.x < 0)
		{
			// Moving left
			leftWeaponSpriteRenderer.sortingOrder = playerSortOrder + 1;
			rightWeaponSpriteRenderer.sortingOrder = playerSortOrder - 1;
		}

		previousPosition = currentPosition;
	}
}
