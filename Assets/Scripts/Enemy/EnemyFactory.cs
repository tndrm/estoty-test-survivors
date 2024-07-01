using UnityEngine;

public class EnemyFactory
{
	public Enemy CreateEnemy(EnemyConfig stats, Vector3 spawnPosition)
	{
		Enemy enemy = GameObject.Instantiate(stats.prefab, spawnPosition, Quaternion.identity);
		enemy.Initialize(stats.health, stats.damage, stats.speed);

		return enemy;
	}
}
