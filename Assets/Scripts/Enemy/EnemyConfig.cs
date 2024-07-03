using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Gameplay/Enemy Config", order = 1)]
public class EnemyConfig : ScriptableObject
{
	public float health;
	public float damage;
	public float speed;
	public Enemy prefab;
}