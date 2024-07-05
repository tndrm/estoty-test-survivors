using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float lifetime;
	[SerializeField] private float speed;
	[SerializeField] private float damage;

	private void Start()
	{
		Destroy(gameObject, lifetime);
	}

	private void Update()
	{
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Enemy enemy;
		collision.TryGetComponent<Enemy>(out enemy);
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}
		Destroy(gameObject);
	}
}