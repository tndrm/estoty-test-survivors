using UnityEngine;
using DG.Tweening;

public class EnemyDieState : IEnemyState
{
	public delegate void EnemyDeath();
	public static event EnemyDeath OnEnemyDeath;

	public void EnterState(Enemy enemy)
	{
		enemy.Animator.SetTrigger("Dead");
		foreach (Transform child in enemy.transform) // delete shadow
		{
			GameObject.Destroy(child.gameObject);
		}
		enemy.gameObject.layer = LayerMask.NameToLayer("Default");
		OnEnemyDeath?.Invoke();
		enemy.LootDropSystem.DropLoots(enemy.transform.position);
		enemy.SpriteRenderer.material.DOFade(0, enemy.EnemyFadeDuration).OnComplete(() => GameObject.Destroy(enemy.gameObject));
	}

	public void UpdateState()
	{
		// No updates needed when dead
	}

	public void ExitState()
	{
		// Any cleanup when exiting the state
	}
}
