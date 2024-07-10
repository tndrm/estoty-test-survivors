using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
	private static GameEntryPoint _instance;
	private Coroutines _coroutines;
	private UIRootView _uiRoot;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void AutostartGame()
	{
		Application.targetFrameRate = 60;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		_instance = new GameEntryPoint();
		_instance.RunGame();
	}
	private GameEntryPoint()
	{
		_coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
		Object.DontDestroyOnLoad(_coroutines.gameObject);

		var prefabUIRoot = Resources.Load<UIRootView>("Prefabs/UI/UIRoot");
		_uiRoot = Object.Instantiate(prefabUIRoot);
		Object.DontDestroyOnLoad(_uiRoot.gameObject);

	}
	private void RunGame()
	{
#if UNITY_EDITOR
		var sceneName = SceneManager.GetActiveScene().name;

		if (sceneName == ScenesNames.GAMEPLAY)
		{
			LoadGamePlay();
			return;
		}
		if (sceneName != ScenesNames.BOOT) return;
#endif
		LoadGamePlay();

	}

	private void LoadGamePlay()
	{
		_uiRoot.ShowLogoScreen();
		_coroutines.StartCoroutine(StartGameplay());
	}

	private void ReloadGameplay()
	{
		_uiRoot.ShowLoadingScreen();
		_coroutines.StartCoroutine(StartGameplay());
	}

	private IEnumerator StartGameplay()
	{

		yield return LoadScene(ScenesNames.BOOT);
		yield return LoadScene(ScenesNames.GAMEPLAY);
		yield return new WaitForSeconds(1);
		var sceneEntryPoint = Object.FindAnyObjectByType<GameplayEntryPoint>();
		sceneEntryPoint.Run();
		sceneEntryPoint.OnGameReloadInvoked += ReloadGameplay;
		_uiRoot.HideLogoAndLoadingScreen();

	}

	private IEnumerator LoadScene(string sceneName)
	{
		yield return SceneManager.LoadSceneAsync(sceneName);
	}
}
