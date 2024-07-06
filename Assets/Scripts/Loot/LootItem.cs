using UnityEngine;

public abstract class LootItem : MonoBehaviour
{
	public abstract void Initialize(LootItemConfig config);
	protected abstract void Apply(GameObject player);
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Apply(other.gameObject);
		}
	}
}
