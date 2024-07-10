using UnityEngine;

public class SpriteOrderManager : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private float lastSpritePosition;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		SetSpriteOrderBasedOnBottomY();
	}
	public void SetSpriteOrderBasedOnBottomY()
	{
		float spriteBottomY = spriteRenderer.bounds.min.y;
		if (lastSpritePosition == spriteBottomY) return;
		lastSpritePosition = spriteBottomY;
		int sortingOrder = Mathf.RoundToInt(-spriteBottomY * 100);
		SetSpriteOrder(sortingOrder);
	}

	private void SetSpriteOrder(int order)
	{
		spriteRenderer.sortingOrder = order;
	}
}