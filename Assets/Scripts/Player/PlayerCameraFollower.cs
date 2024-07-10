using UnityEngine;

public class PlayerCameraFollower : MonoBehaviour
{
	[SerializeField] private Vector3 offset;
	private Transform _player;

	private void Start()
	{
		GameplayEntryPoint gameplayEntryPoint = FindAnyObjectByType<GameplayEntryPoint>();
		gameplayEntryPoint.OnPlayerInstantiated += SetPlayer;
	}
	private void LateUpdate()
	{
		if (_player != null) transform.position = _player.position + offset;
	}

	private void SetPlayer(PlayerMoveController player)
	{
		_player = player.transform;
		ServiceLocator<object> serviceLocator = GameplayEntryPoint.ServiceLocator;

		serviceLocator.Register(this);
	}
}