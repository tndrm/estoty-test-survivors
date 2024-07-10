using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private float spawnPadding = 1f;
	private List<EnemyConfig> enemyTypes;

	private float spawnRate;
	private float enemySpawnIncreaseCoefficient;

	private float nextSpawnTime = 0f;
	private Camera playerCamera;

	private void Start()
	{
		playerCamera = Camera.main;
		GameplayEntryPoint gameEntryPoint = ServiceLocator.Get<GameplayEntryPoint>();
		spawnRate = gameEntryPoint.currentLevelConfig.enemySpawnRate;
		enemySpawnIncreaseCoefficient = gameEntryPoint.currentLevelConfig.enemySpawnIncreaseCoefficient;
		enemyTypes = gameEntryPoint.currentLevelConfig.enemies;
	}


	private void Update()
	{
		if (Time.time >= nextSpawnTime)
		{
			SpawnEnemy();
			nextSpawnTime = Time.time + spawnRate;
			spawnRate *= enemySpawnIncreaseCoefficient;
		}
	}

	private void SpawnEnemy()
	{
		if (playerCamera == null) return;
		Vector3 spawnPosition = GetRandomPositionOutsideCamera();
		EnemyConfig randomEnemyStats = enemyTypes[Random.Range(0, enemyTypes.Count)];
		Enemy enemy = GameObject.Instantiate(randomEnemyStats.prefab, spawnPosition, Quaternion.identity, transform);
		enemy.Initialize(randomEnemyStats);
	}

	private Vector3 GetRandomPositionOutsideCamera()
	{
		Vector3 screenBottomLeft = playerCamera.ViewportToWorldPoint(Vector2.zero);
		Vector2 screenTopRight = playerCamera.ViewportToWorldPoint(Vector2.one);
		
		int side = Random.Range(0, 4); // random side to spawn the enemy
		Vector3 spawnPosition = Vector2.zero;

		switch (side)
		{
			case 0: // Left
				spawnPosition = new Vector2(screenBottomLeft.x - spawnPadding, Random.Range(screenBottomLeft.y, screenTopRight.y));
				break;
			case 1: // Right
				spawnPosition = new Vector2(screenTopRight.x + spawnPadding, Random.Range(screenBottomLeft.y, screenTopRight.y));
				break;
			case 2: // Bottom
				spawnPosition = new Vector2(Random.Range(screenBottomLeft.x, screenTopRight.x), screenBottomLeft.y - spawnPadding);
				break;
			case 3: // Top
				spawnPosition = new Vector2(Random.Range(screenBottomLeft.x, screenTopRight.x), screenTopRight.y + spawnPadding);
				break;
		}

		return spawnPosition;
	}
}
