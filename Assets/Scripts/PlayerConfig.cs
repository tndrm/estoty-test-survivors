using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Gameplay/PlayerConfig", order = 1)]
public class PlayerConfig : ScriptableObject
{
	public float health;
	public float damage;
	public float speed;
	public PlayerController prefab;
}