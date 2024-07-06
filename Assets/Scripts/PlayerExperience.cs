using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
	private int currentExperience = 0;
	public int experienceToNextLevel { get; private set; }

	public delegate void ExperienceChanged(int currentExperience);
	public event ExperienceChanged OnExperienceChanged;

	private void Awake()
	{
		experienceToNextLevel = 100;

		ServiceLocator.Register(this);
	}
	private void Start()
	{
		OnExperienceChanged?.Invoke(currentExperience);
	}
	public void AddExperience(int amount)
	{
		currentExperience += amount;
		OnExperienceChanged?.Invoke(currentExperience);

		if (currentExperience >= experienceToNextLevel)
		{
			LevelUp();
		}
	}

	private void LevelUp()
	{
		currentExperience -= experienceToNextLevel;
		experienceToNextLevel = Mathf.CeilToInt(experienceToNextLevel * 1.5f);
		Debug.Log("Player leveled up!");
	}
}
