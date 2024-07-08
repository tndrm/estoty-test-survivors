using UnityEngine;

public class EnemyAttackState : IEnemyState
{
	private Enemy _enemy;
	private Transform _player;
	private int _attackDamage;
	private PlayerHealth _playerHealth;
	private float _attackInterval;
	private float nextAttackTime;


	public void EnterState(Enemy enemy)
	{
		_enemy = enemy;
		_playerHealth = enemy.player.GetComponent<PlayerHealth>();
		_attackDamage = enemy._damage;
		_attackInterval = enemy._attackInterval;
		_enemy.animator.SetBool("Hit", true);
	}

	public void UpdateState()
	{
		if (Time.time >= nextAttackTime)
		{
			_playerHealth.TakeDamage(_attackDamage);
			nextAttackTime = Time.time + _attackInterval;
		}
	}

	public void ExitState()
	{
		nextAttackTime = 0;
		_enemy.animator.SetBool("Hit", false);

	}
}
