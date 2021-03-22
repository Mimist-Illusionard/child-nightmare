using UnityEngine;


public sealed class InteractLogic 
{
    private GameObject _raycastPoint;
    private float _rayDistance;
    private RaycastHit _hit;

    public InteractLogic(GameObject playerBody, float rayDistance)
    {
        _raycastPoint = playerBody;
        _rayDistance = rayDistance;
    }

    public void Logic()
    {
        Debug.DrawRay(_raycastPoint.transform.position, _raycastPoint.transform.forward * _rayDistance, Color.red);

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(_raycastPoint.transform.position, _raycastPoint.transform.forward, out _hit, _rayDistance))
            {
                if (_hit.collider.gameObject.tag == "Interactive")
                {
                    var interactiveObject = _hit.collider.gameObject.GetComponent<IInteractive>();
                    if (interactiveObject.IsInteractiveByPlayer)
                    {
                        interactiveObject.InteractLogic();
                    } 
                    else
                    {
                        interactiveObject.BlockedInteractLogic();
                    }
                }
            }
        }
    }
}
