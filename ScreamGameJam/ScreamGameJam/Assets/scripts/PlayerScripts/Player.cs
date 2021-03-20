using UnityEngine;


public sealed class Player : MonoBehaviour
{
    private CharacterController _characterController;

    private InteractLogic _interactLogic;
    private Movement _movement;

    [SerializeField] private float _rayDistance;
    [SerializeField] private float _movementSpeed;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();

        _interactLogic = new InteractLogic(GetComponentInChildren<Camera>().gameObject, _rayDistance);
        _movement = new Movement(gameObject, _characterController, _movementSpeed);
    }

    private void Update()
    {
        _interactLogic.Logic();
    }

    private void FixedUpdate()
    {
        _movement.Logic();
    }
}