using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Gameplay/Level Config", order = 1)]
public class LevelConfig : ScriptableObject
{
	public int level;

	[Header("Player Settings")]

	public int playerMaxExpirience;
	public int playerMaxHealth;
	public float playerSpeed;

	[Header("Enemies Settings")]
	
	public List<EnemyConfig> enemies;
	public float enemySpawnRate;
	public float enemySpawnIncreaseCoefficient;

}