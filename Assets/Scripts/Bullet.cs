using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float lifetime;
	[SerializeField] private float speed;
	[SerializeField] private int damage;

	private void Start()
	{
		Destroy(gameObject, lifetime);
	}

	private void Update()
	{
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Enemy enemy;
		collision.gameObject.TryGetComponent<Enemy>(out enemy);
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}
		Destroy(gameObject);
	}
}