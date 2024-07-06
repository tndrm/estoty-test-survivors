using UnityEngine;

public class HealthPotion : LootItem
{
	public int Amount => healthAmount;
	private int healthAmount;

	public override void Initialize(LootItemConfig config)
	{
		healthAmount = config.amount;
	}

	protected override void Apply(GameObject player)
	{
		PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
		playerHealth.Heal(healthAmount);
		Destroy(gameObject);
	}
}
