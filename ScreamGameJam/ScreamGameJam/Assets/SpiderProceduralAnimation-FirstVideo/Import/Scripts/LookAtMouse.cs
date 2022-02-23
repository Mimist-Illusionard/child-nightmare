using UnityEngine;


public class LookAtMouse : Executable
{
    public Transform _lookingObject;
    public float _speed;
    private float _verticalLookRotation;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void Execute()
    {
        Look();
    }

    private void Look()
    {
        //transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * _speed);

        _verticalLookRotation += Input.GetAxisRaw("Mouse X") * _speed;
        //_verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -90f, 90f);

        _lookingObject.localEulerAngles = Vector3.up * _verticalLookRotation;
    }

}

