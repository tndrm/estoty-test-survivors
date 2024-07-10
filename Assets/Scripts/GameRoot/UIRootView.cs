using UnityEngine;

public class UIRootView : MonoBehaviour
{

	[SerializeField] private GameObject _loadingScreen;
	[SerializeField] private Transform _uiSceneContainer;
	[SerializeField] private GameObject _logoScreen;

	private void Awake()
	{
		HideLogoAndLoadingScreen();
	}

	public void ShowLoadingScreen()
	{
		_loadingScreen.SetActive(true);
	}
	public void HideLogoAndLoadingScreen()
	{
		_loadingScreen.SetActive(false);
		_logoScreen.SetActive(false);

	}
	public void ShowLogoScreen()
	{
		_logoScreen.SetActive(true);
	}

	public void AttachSceneUI(GameObject sceneUI)
	{
		ClearSceneUI();
		sceneUI.transform.SetParent(_uiSceneContainer, false);
	}

	private void ClearSceneUI()
	{
		var childCount = _uiSceneContainer.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Destroy(_uiSceneContainer.GetChild(i).gameObject);
		}
	}
}
