using System;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
	private int currentExperience = 0;
	public int experienceToNextLevel { get; private set; }

	public event Action<int> OnExperienceChanged;
	public event Action OnExpirienceFull;


	private void Awake()
	{

		ServiceLocator.Register(this);
	}

	private void Start()
	{
		GameplayEntryPoint gameEntryPoint = ServiceLocator.Get<GameplayEntryPoint>();
		experienceToNextLevel = gameEntryPoint.currentLevelConfig.playerMaxExpirience;
		OnExperienceChanged?.Invoke(currentExperience);
	}
	public void AddExperience(int amount)
	{
		currentExperience += amount;
		OnExperienceChanged?.Invoke(currentExperience);

		if (currentExperience >= experienceToNextLevel)
		{
			OnExpirienceFull?.Invoke();
		}
	}

	private void LevelUp()
	{
		currentExperience -= experienceToNextLevel;
		experienceToNextLevel = Mathf.CeilToInt(experienceToNextLevel * 1.5f);
		Debug.Log("Player leveled up!");
	}
}
