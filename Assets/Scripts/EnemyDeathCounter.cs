using UnityEngine;

public class EnemyDeathCounter : MonoBehaviour
{
	private int enemyDeathCount = 0;

	public delegate void EnemyDeathEventHandler(int enemyDeathCount);
	public event EnemyDeathEventHandler OnEnemyDeathCountChanged;

	private void Awake()
	{
		ServiceLocator.Register(this);
	}
	private void OnEnable()
	{
		Enemy.OnEnemyDeath += HandleEnemyDeath;
	}

	private void OnDisable()
	{
		Enemy.OnEnemyDeath -= HandleEnemyDeath;
	}

	private void HandleEnemyDeath()
	{
		enemyDeathCount++;
		OnEnemyDeathCountChanged?.Invoke(enemyDeathCount);
	}
}
