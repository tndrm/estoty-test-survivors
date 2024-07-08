using System.Xml;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] float enemyFadeDuration = 2f;
	private float health;
	private float damage;
	private float speed;
	private Transform player;
	private SpriteRenderer spriteRenderer;
	private LootDropSystem lootDropSystem;
	private Animator animator;

	private IEnemyState currentState;

	public Transform Player => player;
	public SpriteRenderer SpriteRenderer => spriteRenderer;
	public Animator Animator => animator;
	public LootDropSystem LootDropSystem => lootDropSystem;
	public float Speed => speed;
	public float EnemyFadeDuration => enemyFadeDuration;

	private void Start()
	{
		player = ServiceLocator.Get<PlayerController>().transform;
		lootDropSystem = ServiceLocator.Get<LootDropSystem>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();

		SetState(new EnemyChaseState());
	}

	public void Initialize(float health, float damage, float speed)
	{
		this.health = health;
		this.damage = damage;
		this.speed = speed;
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

	public void TakeDamage(float amount)
	{
		if (currentState is EnemyDieState) return;

			health -= amount;
		if (health <= 0)
		{
			SetState(new EnemyDieState());
		}
	}

	public void Attack()
	{
		if (currentState is EnemyDieState) return;

		throw new System.NotImplementedException();
	}
}
