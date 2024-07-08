using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class LootDropSystem : MonoBehaviour
{
	[SerializeField] private LootItemConfig experienceGem;
	[SerializeField] private List<LootItemConfig> otherLoots = new List<LootItemConfig>();
	[SerializeField] private float spawnRadius = 1.5f;
	[SerializeField] private float scatterDuration = 0.2f;

	private void Awake()
	{
		ServiceLocator.Register(this);
	}
	public void DropLoots(Vector3 position)
	{
		spawnLoot(experienceGem, position);
		if (otherLoots.Count > 0)
		{
			LootItemConfig randomLootConfig = otherLoots[Random.Range(0, otherLoots.Count - 1)];
			spawnLoot(randomLootConfig, position);
		}

	}

	private void spawnLoot(LootItemConfig loot, Vector3 position)
	{
		LootItem lootInstance = Instantiate(loot.lootPrefab, position, Quaternion.identity, transform).GetComponent<LootItem>();
		lootInstance.Initialize(loot);
		ShowDropLootAnomation(lootInstance);
	}

	private void ShowDropLootAnomation(LootItem lootItem)
	{
		Vector2 randomDirection = Random.insideUnitCircle.normalized * spawnRadius;

		Vector3 targetPosition = lootItem.transform.position + new Vector3(randomDirection.x, randomDirection.y, 0);

		lootItem.transform.DOJump(targetPosition, .1f, 2, scatterDuration).SetEase(Ease.OutQuad);
		lootItem.transform.localScale = Vector3.zero;
		lootItem.transform.DOScale(1, scatterDuration / 2).SetEase(Ease.OutQuad);
	}
}