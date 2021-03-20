using UnityEngine;


public sealed class InteractLogic 
{
    private GameObject _playerBody;
    private float _rayDistance;
    private RaycastHit _hit;

    public InteractLogic(GameObject playerBody, float rayDistance)
    {
        _playerBody = playerBody;
        _rayDistance = rayDistance;
    }

    public void Logic()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(_playerBody.transform.position, _playerBody.transform.forward, out _hit, _rayDistance))
            {
                if (_hit.collider.gameObject.tag == "Interact")
                {
                    var interactiveObject = _hit.collider.gameObject.GetComponent<IInteractive>();
                    if (interactiveObject.IsInteractiveByPlayer)
                    {
                        interactiveObject.InteractLogic();
                    }
                }
            }
        }
    }
}
