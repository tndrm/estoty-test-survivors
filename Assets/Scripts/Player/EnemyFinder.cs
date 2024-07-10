using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
	[SerializeField] private float searchRadius = 10f;
	[SerializeField] private LayerMask enemyLayer;

	private void Awake()
	{
		ServiceLocator.Register(this);
	}
	public Transform FindClosestEnemy()
	{
		float closestDistance = searchRadius;
		Transform closestEnemy = null;

		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, searchRadius, enemyLayer);
		foreach (Collider2D enemy in enemies)
		{
			float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < closestDistance)
			{
				closestDistance = distanceToEnemy;
				closestEnemy = enemy.transform;
			}
		}
		return closestEnemy;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, searchRadius);
	}
}