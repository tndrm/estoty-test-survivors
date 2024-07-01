
using UnityEngine;

public class ExamplePlayerController : MonoBehaviour
{
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";

	private float inputHorizontal;
	private float inputVertical;
	public float speed = 5.0f;

	void Update()
	{
		// Получение ввода от SimpleInput
		inputHorizontal = SimpleInput.GetAxisRaw(horizontalAxis);
		inputVertical = SimpleInput.GetAxis(verticalAxis);
		Vector3 move = new Vector3(inputHorizontal, inputVertical, 0);
		transform.Translate(move * speed * Time.deltaTime);
	}
}