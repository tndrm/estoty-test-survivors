using DG.Tweening;
using UnityEngine;

public abstract class LootItem : MonoBehaviour
{
	[SerializeField] private float applyDistance = .5f;
	[SerializeField] private float attractDuration = .2f;
	private GameObject player;


	public abstract void Initialize(LootItemConfig config);
	protected abstract void Apply(GameObject player);
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			player = other.gameObject;
			MoveToPlayer();
		}
	}

	private void Update()
	{
		if (player == null) return;
		if (Vector2.Distance(player.transform.position, transform.position) < applyDistance)
		{
			transform.DOKill();
			Apply(player);
		}
	}

	private void MoveToPlayer()
	{
		transform.DOMove(player.transform.position, attractDuration).SetEase(Ease.OutQuad);
		transform.DOScale(0, attractDuration).SetEase(Ease.OutQuad);
	}
}
