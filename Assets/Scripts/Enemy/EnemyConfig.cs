using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Gameplay/Enemy Config", order = 1)]
public class EnemyConfig : ScriptableObject
{
	public int health;
	public int damage;
	public float attackInterval;
	public float speed;
	public Enemy prefab;
}