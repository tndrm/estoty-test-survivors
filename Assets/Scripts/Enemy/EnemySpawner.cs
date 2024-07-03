using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private EnemyConfig[] enemyTypes;
	[SerializeField] private float spawnRate = 5f;
	[SerializeField] private float spawnPadding = 1f;

	private float nextSpawnTime = 0f;
	private Camera playerCamera;
	private EnemyFactory enemyFactory;
	private List<Enemy> spawnedEnemies;

	private void Start()
	{
		playerCamera = ServiceLocator.Get<PlayerCameraFollower>().GetComponent<Camera>();

		spawnedEnemies = new List<Enemy>();
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
		if (playerCamera == null) return;
		Vector3 spawnPosition = GetRandomPositionOutsideCamera();
		EnemyConfig randomEnemyStats = enemyTypes[Random.Range(0, enemyTypes.Length)];
		spawnedEnemies.Add(enemyFactory.CreateEnemy(randomEnemyStats, spawnPosition, transform));
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
