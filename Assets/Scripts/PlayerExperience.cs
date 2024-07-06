using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
	public int currentExperience = 0;
	public int experienceToNextLevel = 100;

	public void AddExperience(int amount)
	{
		currentExperience += amount;
		if (currentExperience >= experienceToNextLevel)
		{
			LevelUp();
		}
		Debug.Log($"Player gained experience. Current experience: {currentExperience}");
	}

	private void LevelUp()
	{
		currentExperience -= experienceToNextLevel;
		experienceToNextLevel = Mathf.CeilToInt(experienceToNextLevel * 1.5f);
		Debug.Log("Player leveled up!");
	}
}
