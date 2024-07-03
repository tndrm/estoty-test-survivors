using UnityEngine;

public class EnemyFactory
{
	public Enemy CreateEnemy(EnemyConfig stats, Vector3 spawnPosition, Transform parent)
	{
		Enemy enemy = GameObject.Instantiate(stats.prefab, spawnPosition, Quaternion.identity, parent);
		enemy.Initialize(stats.health, stats.damage, stats.speed);

		return enemy;
	}
}
