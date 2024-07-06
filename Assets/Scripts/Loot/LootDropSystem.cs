using System.Collections.Generic;
using UnityEngine;

public class LootDropSystem : MonoBehaviour
{
	[SerializeField] private LootItemConfig experienceGem;
	[SerializeField] private List<LootItemConfig> loots = new List<LootItemConfig>();

	private void Awake()
	{
		ServiceLocator.Register(this);
	}
	public void DropLoot(Vector3 position)
	{
		LootItem experienceLoot = Instantiate(experienceGem.lootPrefab, position, Quaternion.identity).GetComponent<LootItem>();
		experienceLoot.Initialize(experienceGem);


		LootItemConfig randomLootConfig = loots[Random.Range(0, loots.Count - 1)];
		LootItem loot = Instantiate(randomLootConfig.lootPrefab, position, Quaternion.identity).GetComponent<LootItem>();
		loot.Initialize(randomLootConfig);
	}
}