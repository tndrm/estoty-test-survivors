using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth = 100;
	private int currentHealth;

	private void Start()
	{
		currentHealth = maxHealth;
	}

	public void Heal(int amount)
	{
		currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
		Debug.Log($"Player healed. Current health: {currentHealth}");
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			Die();
		}
		Debug.Log($"Player took damage. Current health: {currentHealth}");
	}

	private void Die()
	{
		Debug.Log("Player died.");
	}
}
