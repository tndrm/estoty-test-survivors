using System;
using UnityEngine;

public class GameplayEntryPoint : MonoBehaviour
{

	public event Action<PlayerMoveController> OnPlayerInstantiated;
	public event Action OnGameReloadInvoked;

	[SerializeField] LevelConfig[] levels;
	[SerializeField] int levelIndex;
	[SerializeField] PlayerMoveController playerPrefab;
	[SerializeField] GameObject environmentPrefab;
	[SerializeField] GameObject gameObjectSpawnerPrefab;
	[SerializeField] GameObject gameplayUIprefab;

	public LevelConfig currentLevelConfig { get; private set; }

	public void Run()
	{
		if (levels != null && levels.Length > 0 && levelIndex >= 0 && levelIndex < levels.Length)
		{
			Debug.Log("Gameplay scene Loaded");
			currentLevelConfig = levels[levelIndex];
			LoadLevel(currentLevelConfig);
			ServiceLocator.Register(this);
		}
		else
		{
			Debug.LogError("Invalid level index or no levels assigned.");
		}
	}

	public void ReloadGame()
	{
		OnGameReloadInvoked?.Invoke();
	}

	private void LoadLevel(LevelConfig levelData)
	{
		if (playerPrefab != null)
		{
			PlayerMoveController player = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
			OnPlayerInstantiated?.Invoke(player);
		}

		if (environmentPrefab != null)
		{
			GameObject environment = Instantiate(environmentPrefab, Vector2.zero, Quaternion.identity);
		}
		
		if (gameObjectSpawnerPrefab != null)
		{
			GameObject gameObjectSpawner = Instantiate(gameObjectSpawnerPrefab, Vector2.zero, Quaternion.identity);
		}		
		if (gameplayUIprefab!= null)
		{
			GameObject UIgameObject = Instantiate(gameplayUIprefab, Vector2.zero, Quaternion.identity);
		}
	}
}
