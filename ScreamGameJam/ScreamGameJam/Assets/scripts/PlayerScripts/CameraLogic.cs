using UnityEngine;


public sealed class CameraLogic : MonoBehaviour
{
    private Transform _cameraTransform;
    public Transform _playerBody;

    private float xRotation = 0;

    [SerializeField] private float _mouseSensivity;

    private void Start()
    {
        _cameraTransform = gameObject.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        _cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseX);
    }

    public void SetSensivity(float sensivity)
    {
        _mouseSensivity = sensivity;
    }
}
