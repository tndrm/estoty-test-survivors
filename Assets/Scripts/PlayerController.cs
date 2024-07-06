using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private string horizontalAxis = "Horizontal";
	[SerializeField] private string verticalAxis = "Vertical";
	[SerializeField] private float moveSpeed = 5.0f;

	private float inputHorizontal;
	private float inputVertical;
	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rb;


	private void Awake()
	{
		ServiceLocator.Register(this);
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
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
		animator.SetBool("Run", moveDirection != Vector2.zero);

		moveDirection.Normalize();
		if (moveDirection.x != 0)
		{
			spriteRenderer.flipX = moveDirection.x < 0;
		}

		rb.velocity = moveDirection * moveSpeed;
	}
}
