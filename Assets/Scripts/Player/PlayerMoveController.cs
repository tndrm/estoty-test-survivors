using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoveController : MonoBehaviour
{
	[SerializeField] private string horizontalAxis = "Horizontal";
	[SerializeField] private string verticalAxis = "Vertical";

	private float moveSpeed;
	private float inputHorizontal;
	private float inputVertical;
	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rb;
	private ServiceLocator<object> serviceLocator;

	private void Awake()
	{
		serviceLocator = GameplayEntryPoint.ServiceLocator;

		serviceLocator.Register(this);
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}
	private void Start()
	{
		GameplayEntryPoint gameEntryPoint = serviceLocator.Get<GameplayEntryPoint>();
		moveSpeed = gameEntryPoint.currentLevelConfig.playerSpeed;
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
