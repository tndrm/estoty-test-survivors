using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth { get; private set; }
	public int currentHealth { get; private set; }

	public event Action<int> OnHealthChanged;
	public event Action OnPlayerDied;
	private ServiceLocator<object> serviceLocator;



	private void Awake()
	{
		serviceLocator = GameplayEntryPoint.ServiceLocator;

		serviceLocator.Register(this);
	}
	private void Start()
	{
		GameplayEntryPoint gameEntryPoint = serviceLocator.Get<GameplayEntryPoint>();
		maxHealth = gameEntryPoint.currentLevelConfig.playerMaxHealth;
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
		OnPlayerDied?.Invoke();
	}
}
