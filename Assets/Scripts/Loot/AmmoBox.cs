using UnityEngine;

public class AmmoBox : LootItem
{
	public int Amount => ammoAmount;
	private int ammoAmount;

	public override void Initialize(LootItemConfig config)
	{
		ammoAmount = config.amount;
	}

	protected override void Apply(GameObject player)
	{
		player.GetComponent<PlayerWeapon>().Reload(ammoAmount);
		Destroy(gameObject);
	}
}
