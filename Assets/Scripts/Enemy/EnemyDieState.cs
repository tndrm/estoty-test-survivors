using DG.Tweening;
using UnityEngine;

public class EnemyDieState : IEnemyState
{
	public delegate void EnemyDeath();
	public static event EnemyDeath OnEnemyDeath;

	public void EnterState(Enemy enemy)
	{
		enemy.animator.SetTrigger("Dead");
		foreach (Transform child in enemy.transform) // delete shadow
		{
			GameObject.Destroy(child.gameObject);
		}
		enemy.gameObject.layer = LayerMask.NameToLayer("Default");
		OnEnemyDeath?.Invoke();
		enemy.lootDropSystem.DropLoots(enemy.transform.position);
		enemy.spriteRenderer.material.DOFade(0, enemy.enemyFadeDuration).OnComplete(() => GameObject.Destroy(enemy.gameObject));
	}

	public void UpdateState() { }

	public void ExitState() { }
}
