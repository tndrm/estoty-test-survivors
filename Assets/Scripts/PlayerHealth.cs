using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth { get; private set; }
	private int currentHealth;

	public delegate void HealthChanged(int currentHealth);
	public event HealthChanged OnHealthChanged;


	private void Awake()
	{
		ServiceLocator.Register(this);
		maxHealth = 100;
	}
	private void Start()
	{
		currentHealth = maxHealth;
		OnHealthChanged?.Invoke(currentHealth);
	}

	public void Heal(int amount)
	{
		currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
		OnHealthChanged?.Invoke(currentHealth);
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			Die();
		}
		OnHealthChanged?.Invoke(currentHealth);
	}

	private void Die()
	{
		Debug.Log("Player died.");
	}
}
