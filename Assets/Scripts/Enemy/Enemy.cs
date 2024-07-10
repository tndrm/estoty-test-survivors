using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float enemyFadeDuration = 2f;
	public int _health { get; private set; }
	public int _damage { get; private set; }
	public float _speed { get; private set; }
	public float _attackInterval { get; private set; }
	public Transform player { get; private set; }
	public SpriteRenderer spriteRenderer { get; private set; }
	public LootDropSystem lootDropSystem { get; private set; }
	public Animator animator { get; private set; }

	private IEnemyState currentState;

	private void Start()
	{
		player = ServiceLocator.Get<PlayerMoveController>().transform;
		lootDropSystem = ServiceLocator.Get<LootDropSystem>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();

		SetState(new EnemyChaseState());
	}

	public void Initialize(EnemyConfig config)
	{
		_health = config.health;
		_damage = config.damage;
		_speed = config.speed;
		_attackInterval = config.attackInterval;
	}

	private void Update()
	{
		currentState?.UpdateState();
	}

	public void SetState(IEnemyState newState)
	{
		currentState?.ExitState();
		currentState = newState;
		currentState.EnterState(this);
	}

	public void TakeDamage(int amount)
	{
		if (currentState is EnemyDieState) return;

		_health -= amount;
		if (_health <= 0)
		{
			SetState(new EnemyDieState());
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (currentState is EnemyDieState) return;
		if (collision.gameObject.CompareTag("Player")) SetState(new EnemyAttackState());
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (currentState is EnemyDieState) return;
		if (collision.gameObject.CompareTag("Player")) SetState(new EnemyChaseState());
	}
}
