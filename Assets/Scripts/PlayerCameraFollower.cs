using UnityEngine;

public class PlayerCameraFollower : MonoBehaviour
{
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	private Transform player;

	private void Awake()
	{
		ServiceLocator.Register(this);
	}
	private void Start()
	{
		player = ServiceLocator.Get<PlayerMoveController>().transform;
	}
	private void LateUpdate()
	{
		Vector3 desiredPosition = player.position + offset;

		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

		transform.position = smoothedPosition;
	}
}