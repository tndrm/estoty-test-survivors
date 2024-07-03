using UnityEngine;

public class Enemy : MonoBehaviour
{
	private float health;
	private float damage;
	private float speed;
	private Transform player;
	private SpriteRenderer spriteRenderer;

	private void Start()
	{
		player = ServiceLocator.Get<PlayerController>().transform;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Initialize(float health, float damage, float speed)
	{
		this.health = health;
		this.damage = damage;
		this.speed = speed;
	}

	private void Update()
	{
		ChasePlayer();
	}

	private void ChasePlayer()
	{
		if (player != null)
		{
			Vector3 direction = player.position - transform.position;
			transform.position += direction.normalized * speed * Time.deltaTime;
			spriteRenderer.flipX = direction.x < 0;
		}
	}

	public void TakeDamage(float amount)
	{
		health -= amount;
		if (health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		Destroy(gameObject);
	}

	public void Attack()
	{
		throw new System.NotImplementedException();
	}
}
