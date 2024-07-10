using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	[SerializeField] private Slider healthSlider;
	[SerializeField] private Slider experienceSlider;
	[SerializeField] private Text enemyDeathText;
	[SerializeField] private GameObject winScreen;
	[SerializeField] private GameObject loseScreen;


	private PlayerHealth playerHealth;
	private PlayerExperience playerExperience;
	private EnemyDeathCounter enemyDeathCounter;
	private GameplayEntryPoint gameplayEntryPoint;

	private void Start()
	{
		winScreen.SetActive(false);
		loseScreen.SetActive(false);
		playerExperience = ServiceLocator.Get<PlayerExperience>();
		playerHealth = ServiceLocator.Get<PlayerHealth>();
		enemyDeathCounter = ServiceLocator.Get<EnemyDeathCounter>();
		healthSlider.maxValue = playerHealth.maxHealth;
		UpdateHealthUI(playerHealth.currentHealth);

		experienceSlider.maxValue = playerExperience.experienceToNextLevel;

		playerHealth.OnHealthChanged += UpdateHealthUI;
		playerHealth.OnPlayerDied += ShowLoseScreen;

		playerExperience.OnExperienceChanged += UpdateExperienceUI;
		playerExperience.OnExpirienceFull += ShowWinScreen;

		enemyDeathCounter.OnEnemyDeathCountChanged += UpdateDeathCounterUI;

		gameplayEntryPoint = ServiceLocator.Get<GameplayEntryPoint>();

	}

	private void ShowWinScreen()
	{
		winScreen.SetActive(true);
	}

	private void ShowLoseScreen()
	{
		loseScreen.SetActive(true);
	}

	public void OnReloadButtonClick()
	{
		gameplayEntryPoint.ReloadGame();
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
