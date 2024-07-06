using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	[SerializeField] private Slider healthSlider;
	[SerializeField] private Slider experienceSlider;
	[SerializeField] private Text enemyDeathText;


	private PlayerHealth playerHealth;
	private PlayerExperience playerExperience;
	private EnemyDeathCounter enemyDeathCounter;

	private void Start()
	{
		playerExperience = ServiceLocator.Get<PlayerExperience>();
		playerHealth = ServiceLocator.Get<PlayerHealth>();
		enemyDeathCounter = ServiceLocator.Get<EnemyDeathCounter>();

		healthSlider.maxValue = playerHealth.maxHealth;
		experienceSlider.maxValue = playerExperience.experienceToNextLevel;

		playerHealth.OnHealthChanged += UpdateHealthUI;
		playerExperience.OnExperienceChanged += UpdateExperienceUI;
		enemyDeathCounter.OnEnemyDeathCountChanged += UpdateDeathCounterUI;
	}

	private void OnDisable()
	{
		playerHealth.OnHealthChanged -= UpdateHealthUI;
		playerExperience.OnExperienceChanged -= UpdateExperienceUI;
	}

	private void UpdateHealthUI(int currentHealth)
	{
		healthSlider.value = currentHealth;
	}

	private void UpdateExperienceUI(int currentExperience)
	{
		experienceSlider.value = currentExperience;
	}

	private void UpdateDeathCounterUI(int currentDeathes)
	{
		enemyDeathText.text = currentDeathes.ToString();
	}
}
