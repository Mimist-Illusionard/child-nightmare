using UnityEngine;


public class Player : Executable
{
	[SerializeField] Transform _cameraHolder;
	[SerializeField] public float _mouseSensitivity, _walkSpeed, _gravityForce;

	private CharacterController _characterController;
	private Vector3 _velocity;

	private float _currentSpeed;
	private float _verticalLookRotation;

	private void Awake()
	{
		_characterController = GetComponent<CharacterController>();
	}

    public override void Start()
    {
        base.Start();

		if (FindObjectOfType<Menu>())
			_mouseSensitivity = FindObjectOfType<Menu>().Sens;

		SwitchCursorMode();

		_currentSpeed = _walkSpeed;
	}

    public override void Execute()
	{
		if (gameObject.GetComponent<Player>().enabled == false) return;

		Look();
		Move();
		GameGravity();

		if (Input.GetKeyDown(KeyCode.Escape)) SwitchCursorMode();
	}

	private void Look()
	{
		transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * _mouseSensitivity);

		_verticalLookRotation += Input.GetAxisRaw("Mouse Y") * _mouseSensitivity;
		_verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -90f, 90f);

		_cameraHolder.localEulerAngles = Vector3.left * _verticalLookRotation;
	}

	private void Move()
	{
		if (!_characterController.enabled) return;

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = gameObject.transform.right * x + gameObject.transform.forward * z;
		_characterController.Move(move * _currentSpeed * Time.deltaTime);
	}

	private void GameGravity()
	{
		_velocity.y = _gravityForce;

		_characterController.Move(_velocity * Time.deltaTime);

		if (!_characterController.isGrounded)
			_gravityForce -= 20f * Time.deltaTime;
		else _gravityForce = -1f;
	}

	public void SwitchCursorMode()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
}