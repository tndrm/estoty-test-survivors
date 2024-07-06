using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private string horizontalAxis = "Horizontal";
	[SerializeField] private string verticalAxis = "Vertical";
	[SerializeField] private float moveSpeed = 5.0f;

	private float inputHorizontal;
	private float inputVertical;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rb;


	private void Awake()
	{
		ServiceLocator.Register(this);
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		inputHorizontal = SimpleInput.GetAxis(horizontalAxis);
		inputVertical = SimpleInput.GetAxis(verticalAxis);
		Move();
	}

	private void Move()
	{
		Vector2 moveDirection = new Vector2(inputHorizontal, inputVertical);

		moveDirection.Normalize();
		if (moveDirection.x != 0)
		{
			spriteRenderer.flipX = moveDirection.x < 0;
		}
		rb.velocity = moveDirection * moveSpeed;
	}
}
