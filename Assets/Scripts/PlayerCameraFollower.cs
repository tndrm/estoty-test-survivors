using UnityEngine;

public class PlayerCameraFollower : MonoBehaviour
{
	[SerializeField] private Vector3 offset;

	private Transform player;

	private void Awake()
	{
		ServiceLocator.Register(this);
	}
	private void Start()
	{
		player = ServiceLocator.Get<PlayerController>().transform;
	}
	private void LateUpdate()
	{
		transform.position = player.position + offset;
	}
}