using UnityEngine;

public class Enemy : MonoBehaviour
{
	private float health;
	private float damage;
	private float speed;
	private Transform player;


	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
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
			Vector3 direction = (player.position - transform.position).normalized;
			transform.position += direction * speed * Time.deltaTime;
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
}
