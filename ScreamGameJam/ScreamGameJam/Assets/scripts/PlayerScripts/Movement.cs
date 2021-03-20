using UnityEngine;


public class Movement : ILogic
{
    private CharacterController _characterController;
    private Transform _player;
    private float _speed;

    public Movement(GameObject player, CharacterController characterController, float speed)
    {
        _characterController = characterController;
        _player = player.transform;
        _speed = speed;
    }

    public void Logic()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = _player.right * x + _player.forward * z;

        _characterController.Move(move * _speed * Time.deltaTime);
    }
}
