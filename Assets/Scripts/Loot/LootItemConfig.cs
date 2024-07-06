using UnityEngine;

[CreateAssetMenu(fileName = "LootItemConfig", menuName = "Gameplay/Loot Item Config")]
public class LootItemConfig : ScriptableObject
{
	public enum ItemType
	{
		ExperienceGem,
		HealthPotion,
		AmmoBox
	}

	public ItemType itemType;
	public int amount;
	public GameObject lootPrefab;
}
