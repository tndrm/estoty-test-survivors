using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public float speed = 5.0f;

	private float inputHorizontal;
	private float inputVertical;

	private void Awake()
	{
		ServiceLocator.Register(this);
	}

	void Update()
	{
		inputHorizontal = SimpleInput.GetAxisRaw(horizontalAxis);
		inputVertical = SimpleInput.GetAxis(verticalAxis);
		Vector2 targetPosition = new Vector3(inputHorizontal, inputVertical);

		if (targetPosition != Vector2.zero)
		{
			Move(targetPosition);
		}
	}

	private void Move(Vector2 positiom)
	{
		transform.Translate(positiom * speed * Time.deltaTime);
	}
}