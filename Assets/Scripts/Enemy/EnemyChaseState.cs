using UnityEngine;

public class EnemyChaseState : IEnemyState
{
	private Enemy enemy;
	private Transform player;

	public void EnterState(Enemy enemy)
	{
		this.enemy = enemy;
		this.player = enemy.player;
	}

	public void UpdateState()
	{
		if (player != null)
		{
			Vector3 direction = player.position - enemy.transform.position;
			enemy.transform.position += direction.normalized * enemy._speed * Time.deltaTime;
			enemy.spriteRenderer.flipX = direction.x < 0;
		}
	}
	public void ExitState() { }
}
