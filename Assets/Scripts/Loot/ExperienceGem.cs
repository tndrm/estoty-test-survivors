using UnityEngine;

public class ExperienceGem : LootItem
{
	public int Amount => experienceAmount;
	private int experienceAmount;

	public override void Initialize(LootItemConfig config)
	{
		experienceAmount = config.amount;
	}

	protected override void Apply(GameObject player)
	{
		PlayerExperience playerExperience = player.GetComponent<PlayerExperience>();
		playerExperience.AddExperience(experienceAmount);
		Destroy(gameObject);
	}

}
