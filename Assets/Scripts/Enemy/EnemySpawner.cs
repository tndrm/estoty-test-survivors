using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public EnemyConfig[] enemyTypes;
	public Transform player; // Ссылка на игрока
	public float spawnRadius = 15.0f; // Радиус спавна врагов
	public float spawnRate = 5.0f; // Частота спавна
	private float nextSpawnTime = 0.0f;

	private EnemyFactory enemyFactory;

	private void Start()
	{
		enemyFactory = new EnemyFactory();
	}

	private void Update()
	{
		if (Time.time >= nextSpawnTime)
		{
			SpawnEnemy();
			nextSpawnTime = Time.time + spawnRate;
			spawnRate *= 0.95f;
		}
	}

	private void SpawnEnemy()
	{
		Vector3 spawnPosition = GetRandomPositionOutsideCamera();
		EnemyConfig randomEnemyStats = enemyTypes[Random.Range(0, enemyTypes.Length)];
		enemyFactory.CreateEnemy(randomEnemyStats, spawnPosition);
	}

	private Vector3 GetRandomPositionOutsideCamera()
	{
		Vector3 randomDirection = Random.insideUnitCircle.normalized;
		return player.position + randomDirection * spawnRadius;
	}
}
